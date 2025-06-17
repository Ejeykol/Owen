using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace Owen
{
    public partial class TableViewLite : Form
    {
        private readonly DataSet dataSet = new DataSet();
        private readonly string sqliteConnectionString = ConfigurationManager.ConnectionStrings["LiteConnectionString"].ConnectionString;
        private readonly Dictionary<string, SQLiteDataAdapter> dataAdapters = new Dictionary<string, SQLiteDataAdapter>();
        private string currentTableName = "";
        private string currentRelatedTableName = "";
        private readonly Dictionary<string, List<ForeignKeyInfo>> tableForeignKeys = new Dictionary<string, List<ForeignKeyInfo>>();

        public TableViewLite()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                using (var connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        var tableNames = new List<string>();
                        while (reader.Read())
                        {
                            string tableName = reader["name"].ToString();
                            tableNames.Add(tableName);
                            LoadForeignKeysForTable(connection, tableName);
                        }
                        comboBoxTables.Items.AddRange(tableNames.ToArray());
                        if (comboBoxTables.Items.Count > 0) comboBoxTables.SelectedIndex = 0;
                        else MessageBox.Show("В базе данных не найдено ни одной таблицы, кроме системных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void LoadForeignKeysForTable(SQLiteConnection connection, string tableName)
        {
            tableForeignKeys[tableName] = new List<ForeignKeyInfo>();
            string query = $"PRAGMA foreign_key_list('{tableName}')";
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tableForeignKeys[tableName].Add(new ForeignKeyInfo
                    {
                        FromTable = tableName,
                        FromColumn = reader["from"].ToString(),
                        ToTable = reader["table"].ToString(),
                        ToColumn = reader["to"].ToString()
                    });
                }
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTableName = comboBoxTables.SelectedItem as string;
            if (selectedTableName == null) return;

            currentTableName = selectedTableName;
            LoadSelectedTable(currentTableName);

            comboBoxRelatedTables.Items.Clear();
            var relatedFks = new HashSet<ForeignKeyInfo>(new ForeignKeyInfoComparer());

            // Add ChildToParent relations (current table is FROM)
            if (tableForeignKeys.TryGetValue(currentTableName, out var fksFromCurrent))
            {
                foreach (var fk in fksFromCurrent)
                    relatedFks.Add(new ForeignKeyInfo(fk, RelationType.ChildToParent));
            }

            // Add ParentToChild relations (current table is TO)
            foreach (var entry in tableForeignKeys.Values.SelectMany(list => list))
            {
                if (entry.ToTable == currentTableName)
                    relatedFks.Add(new ForeignKeyInfo(entry, RelationType.ParentToChild));
            }

            foreach (var fk in relatedFks.OrderBy(f => f.DisplayText))
                comboBoxRelatedTables.Items.Add(fk);

            comboBoxRelatedTables.DisplayMember = "DisplayText";
            comboBoxRelatedTables.ValueMember = null;
            comboBoxRelatedTables.Text = "";
            dataGridViewRelated.DataSource = null;
        }

        private void comboBoxRelatedTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ForeignKeyInfo selectedFk = comboBoxRelatedTables.SelectedItem as ForeignKeyInfo;
            if (selectedFk != null)
                LoadRelatedTable(selectedFk);
            else
                dataGridViewRelated.DataSource = null;
        }

        private void LoadSelectedTable(string tableName)
        {
            try
            {
                if (dataSet.Tables.Contains(tableName)) dataSet.Tables[tableName].Clear();
                if (!dataAdapters.ContainsKey(tableName))
                {
                    var connection = new SQLiteConnection(sqliteConnectionString);
                    dataAdapters.Add(tableName, new SQLiteDataAdapter($"SELECT * FROM {tableName}", connection));
                    new SQLiteCommandBuilder(dataAdapters[tableName]);
                }
                dataAdapters[tableName].Fill(dataSet, tableName);
                dataGridViewMain.DataSource = dataSet.Tables[tableName];
                dataGridViewMain.AllowUserToAddRows = true;
                dataGridViewMain.AllowUserToDeleteRows = true;
                dataGridViewMain.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы '{tableName}': {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRelatedTable(ForeignKeyInfo fkInfo)
        {
            DataRowView currentRowView = dataGridViewMain.CurrentRow?.DataBoundItem as DataRowView;
            if (currentRowView == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку в основной таблице, чтобы показать связанные данные.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridViewRelated.DataSource = null;
                return;
            }

            string tableToLoad = (fkInfo.RelationType == RelationType.ChildToParent) ? fkInfo.ToTable : fkInfo.FromTable;
            string filterColumn = (fkInfo.RelationType == RelationType.ChildToParent) ? fkInfo.ToColumn : fkInfo.FromColumn;
            string fkFilterColumn = (fkInfo.RelationType == RelationType.ChildToParent) ? fkInfo.FromColumn : fkInfo.ToColumn;

            object primaryKeyValue = currentRowView.Row[fkFilterColumn];
            if (primaryKeyValue == DBNull.Value || primaryKeyValue == null)
            {
                dataGridViewRelated.DataSource = null;
                return;
            }

            try
            {
                if (dataSet.Tables.Contains(tableToLoad)) dataSet.Tables[tableToLoad].Clear();
                if (!dataAdapters.ContainsKey(tableToLoad))
                {
                    var connection = new SQLiteConnection(sqliteConnectionString);
                    dataAdapters.Add(tableToLoad, new SQLiteDataAdapter($"SELECT * FROM {tableToLoad}", connection));
                    new SQLiteCommandBuilder(dataAdapters[tableToLoad]);
                }
                dataAdapters[tableToLoad].Fill(dataSet, tableToLoad);

                var dv = new DataView(dataSet.Tables[tableToLoad]);
                dv.RowFilter = $"{filterColumn} = {FormatValueForRowFilter(primaryKeyValue)}";
                dataGridViewRelated.DataSource = dv;

                dataGridViewRelated.AllowUserToAddRows = true;
                dataGridViewRelated.AllowUserToDeleteRows = true;
                dataGridViewRelated.ReadOnly = false;
                currentRelatedTableName = tableToLoad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки связанной таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewRelated.DataSource = null;
            }
        }

        private string FormatValueForRowFilter(object value)
        {
            if (value == null || value == DBNull.Value) return "NULL";
            if (value is string || value is char || value is Guid) return $"'{value.ToString().Replace("'", "''")}'";
            return value.ToString();
        }

        private void dataGridViewMain_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataGridView targetDGV = null;
            if (dataGridViewMain.Focused) targetDGV = dataGridViewMain;
            else if (dataGridViewRelated.Focused) targetDGV = dataGridViewRelated;

            if (targetDGV == null) return;

            DataRowView newRowView = null;
            if (targetDGV.DataSource is DataTable dt)
            {
                newRowView = dt.DefaultView.AddNew();
            }
            else if (targetDGV.DataSource is DataView dv)
            {
                newRowView = dv.AddNew();
            }
            else return; // Should not happen

            // Auto-fill FK for child tables
            if (targetDGV == dataGridViewRelated)
            {
                ForeignKeyInfo selectedFk = comboBoxRelatedTables.SelectedItem as ForeignKeyInfo;
                DataRowView currentRowView = dataGridViewMain.CurrentRow?.DataBoundItem as DataRowView;

                if (selectedFk != null && selectedFk.RelationType == RelationType.ParentToChild && currentRowView != null)
                {
                    object parentPKValue = currentRowView.Row[selectedFk.ToColumn];
                    if (parentPKValue != DBNull.Value && parentPKValue != null)
                    {
                        newRowView[selectedFk.FromColumn] = parentPKValue;
                    }
                }
            }

            targetDGV.FirstDisplayedScrollingRowIndex = targetDGV.Rows.Count - 1;
            targetDGV.CurrentCell = targetDGV.Rows[targetDGV.Rows.Count - 1].Cells[0];
            targetDGV.BeginEdit(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tableToSaveName = currentTableName;
            if (dataGridViewRelated.Focused && !string.IsNullOrEmpty(currentRelatedTableName)) tableToSaveName = currentRelatedTableName;
            else if (dataGridViewMain.Focused) tableToSaveName = currentTableName;

            if (string.IsNullOrEmpty(tableToSaveName))
            {
                MessageBox.Show("Не удалось определить, какую таблицу сохранять.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!dataSet.Tables.Contains(tableToSaveName))
            {
                MessageBox.Show($"Таблица '{tableToSaveName}' не найдена в DataSet.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = dataSet.Tables[tableToSaveName];
            SQLiteDataAdapter adapter = dataAdapters[tableToSaveName];

            try
            {
                dataGridViewMain.EndEdit();
                dataGridViewRelated.EndEdit();

                int rowsAffected = adapter.Update(dt);
                MessageBox.Show($"Изменения успешно сохранены в таблице '{tableToSaveName}'. Затронуто строк: {rowsAffected}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (tableToSaveName == currentTableName) LoadSelectedTable(currentTableName);
                else if (tableToSaveName == currentRelatedTableName)
                {
                    ForeignKeyInfo selectedFk = comboBoxRelatedTables.SelectedItem as ForeignKeyInfo;
                    if (selectedFk != null) LoadRelatedTable(selectedFk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений в таблице '{tableToSaveName}': {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView activeDGV = null;
            if (dataGridViewMain.Focused) activeDGV = dataGridViewMain;
            else if (dataGridViewRelated.Focused) activeDGV = dataGridViewRelated;

            if (activeDGV == null || activeDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одну строку для удаления в активной таблице.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableNameToDelete = (activeDGV == dataGridViewMain) ? currentTableName : currentRelatedTableName;
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранные записи?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    for (int i = activeDGV.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        DataRowView drv = activeDGV.SelectedRows[i].DataBoundItem as DataRowView;
                        if (drv != null && !drv.IsNew)
                            drv.Row.Delete();
                    }
                    btnSave_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подготовке к удалению из таблицы '{tableNameToDelete}': {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Ваши существующие методы для скрытия/показа панелей
        private bool gameinfois = true;
        private void GameInfoHideShow_Click(object sender, EventArgs e) { gameinfois = !gameinfois; splitContainerView.Panel1Collapsed = !gameinfois; }
        private bool gameinfois1 = true;
        private void скрытьДоскуToolStripMenuItem1_Click(object sender, EventArgs e) { gameinfois1 = !gameinfois1; splitContainerView.Panel2Collapsed = !gameinfois1; }
        private bool gameinfois2 = true;
        private void скрытьХодыToolStripMenuItem_Click(object sender, EventArgs e) { gameinfois2 = !gameinfois2; panelControls.Visible = gameinfois2; }

        private void toolStripBackButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите вернуться?", "Возврат на форму выбора", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Authorization frm = new Authorization();
                frm.Show();
                this.Hide();
            }
        }

        // --- Класс и перечисление для работы с внешними ключами ---
        public enum RelationType { Unknown, ChildToParent, ParentToChild }

        public class ForeignKeyInfo
        {
            public string FromTable { get; set; }
            public string FromColumn { get; set; }
            public string ToTable { get; set; }
            public string ToColumn { get; set; }
            public RelationType RelationType { get; set; }

            public ForeignKeyInfo() { }
            public ForeignKeyInfo(ForeignKeyInfo other, RelationType relationType)
            {
                FromTable = other.FromTable;
                FromColumn = other.FromColumn;
                ToTable = other.ToTable;
                ToColumn = other.ToColumn;
                RelationType = relationType;
            }

            public string DisplayText
            {
                get
                {
                    if (RelationType == RelationType.ChildToParent) return $"Связь: {FromTable}.{FromColumn} -> {ToTable}.{ToColumn}";
                    if (RelationType == RelationType.ParentToChild) return $"Ссылается: {FromTable} ({FromTable}.{FromColumn} -> {ToTable}.{ToColumn})";
                    return $"Неизвестная связь";
                }
            }

            public override string ToString() { return DisplayText; }
        }

        public class ForeignKeyInfoComparer : IEqualityComparer<ForeignKeyInfo>
        {
            public bool Equals(ForeignKeyInfo x, ForeignKeyInfo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
                return x.FromTable == y.FromTable && x.FromColumn == y.FromColumn &&
                       x.ToTable == y.ToTable && x.ToColumn == y.ToColumn;
            }

            public int GetHashCode(ForeignKeyInfo obj)
            {
                unchecked // Allow overflow for hash computation
                {
                    int hash = 17;
                    hash = hash * 23 + (obj.FromTable?.GetHashCode() ?? 0);
                    hash = hash * 23 + (obj.FromColumn?.GetHashCode() ?? 0);
                    hash = hash * 23 + (obj.ToTable?.GetHashCode() ?? 0);
                    hash = hash * 23 + (obj.ToColumn?.GetHashCode() ?? 0);
                    return hash;
                }
            }
        }

        // Неиспользуемые/пустые обработчики событий
        private void TableViewLite_Load(object sender, EventArgs e) { }
        private void panelControls_Paint(object sender, PaintEventArgs e) { }
        private void splitContainerView_SplitterMoved(object sender, SplitterEventArgs e) { }
        private void dataGridViewRelated_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void toolStripControls_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void toolStripDropDownButton_Click(object sender, EventArgs e) { }
        private void lblTable_Click(object sender, EventArgs e) { }

        private void dataGridViewMain_Click(object sender, EventArgs e)
        {
            ForeignKeyInfo selectedFk = comboBoxRelatedTables.SelectedItem as ForeignKeyInfo;
            if (selectedFk != null)
                LoadRelatedTable(selectedFk);
            else
                dataGridViewRelated.DataSource = null;
        }
    }
}