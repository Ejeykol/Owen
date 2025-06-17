using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite; // Изменение: Используем System.Data.SQLite

namespace Owen
{
    public partial class TableDataForm : Form
    {
        // Делегат для события RowSelected
        public delegate void RowSelectedEventHandler(DataRow selectedRow);
        public event RowSelectedEventHandler RowSelected;

        private List<DataRow> allRows = new List<DataRow>();

        private readonly string _tableName;
        private readonly string _connectionString;
        private DataTable _dataTable; // Будет хранить все данные таблицы

        public TableDataForm(string tableName, string connectionString)
        {
            _tableName = tableName;
            _connectionString = connectionString;
            InitializeComponent();
            LoadTableData();
            FillColumnsComboBox();
        }

        private void TableDataForm_Load(object sender, EventArgs e)
        {
            this.Text = "Таблица из базы данных: " + _tableName;
        }

        private void LoadTableData()
        {
            try
            {
                using (var conn = new SQLiteConnection(_connectionString)) // Изменение: SQLiteConnection
                {
                    conn.Open(); // Открываем соединение явно
                    var adapter = new SQLiteDataAdapter($"SELECT * FROM {_tableName}", conn); // Изменение: SQLiteDataAdapter
                    _dataTable = new DataTable();
                    adapter.Fill(_dataTable);
                    dataGridView.DataSource = _dataTable;
                    allRows = _dataTable.AsEnumerable().ToList(); // Сохраняем все строки для поиска
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных таблицы '{_tableName}': {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Закрыть форму при ошибке
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Игнорируем клик по заголовкам
            {
                // Получаем строку DataGridView
                DataGridViewRow selectedDgvRow = dataGridView.Rows[e.RowIndex];
                // Преобразуем её в DataRow (из исходной DataTable или DataView)
                DataRow row = ((DataRowView)selectedDgvRow.DataBoundItem).Row;

                RowSelected?.Invoke(row); // Вызываем событие, передавая выбранную строку
                this.Close();
            }
        }

        private void SanSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                // Имитируем двойной клик на текущей выбранной строке
                dataGridView_CellDoubleClick(dataGridView, new DataGridViewCellEventArgs(0, dataGridView.CurrentRow.Index));
            }
        }

        private void FillColumnsComboBox() // заполнение комбобокса столбцами
        {
            comboBoxColumns.Items.Clear();
            comboBoxColumns.Items.Add("Все столбцы");
            comboBoxColumns.SelectedIndex = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns) // Добавляем названия всех столбцов
            {
                comboBoxColumns.Items.Add(column.HeaderText);
            }
        }

        // ПОИСК
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBoxSearch.Text.Trim();
                string selectedColumn = comboBoxColumns.SelectedItem.ToString();

                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView.DataSource = _dataTable; // Показываем все данные
                    return;
                }

                // Используем DataView для фильтрации, это более производительно и удобно
                // при повторных поисках
                DataView dv = new DataView(_dataTable);

                string filterExpression = "";

                if (selectedColumn == "Все столбцы")
                {
                    // Создаем OR-условие для всех столбцов
                    var columnFilters = new List<string>();
                    foreach (DataColumn col in _dataTable.Columns)
                    {
                        // Проверяем, что столбец строкового типа или может быть конвертирован
                        if (col.DataType == typeof(string) || col.DataType == typeof(int) || col.DataType == typeof(double))
                        {
                            columnFilters.Add($"Convert([{col.ColumnName}], 'System.String') LIKE '%{searchText.Replace("'", "''")}%'");
                        }
                    }
                    filterExpression = string.Join(" OR ", columnFilters);
                }
                else
                {
                    // Для конкретного столбца
                    filterExpression = $"Convert([{selectedColumn}], 'System.String') LIKE '%{searchText.Replace("'", "''")}%'";
                }

                dv.RowFilter = filterExpression;
                dataGridView.DataSource = dv; // Привязываем отфильтрованные данные
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = ""; // Сброс поиска
            comboBoxColumns.SelectedIndex = 0;
            dataGridView.DataSource = _dataTable; // Показываем все данные
        }
    }
}