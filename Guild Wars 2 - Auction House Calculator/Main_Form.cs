using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guild_Wars_2___Auction_House_Calculator
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            // Set the DataGridView properties
            DataGrid_Calculation.AutoGenerateColumns = false;
            DataGrid_Calculation.AllowUserToAddRows = true;
            DataGrid_Calculation.AllowUserToDeleteRows = true;
            // Add columns to the DataGridView
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Item Name", HeaderText = "Item Name" });

            var rarityColumn = new DataGridViewComboBoxColumn
            {
                Name = "Rarity",
                HeaderText = "Rarity",
                DataSource = new string[]
                {
                    "Junk",
                    "Basic",
                    "Fine",
                    "Masterwork",
                    "Rare",
                    "Exotic",
                    "Ascended",
                    "Legendary"
                },
                FlatStyle = FlatStyle.Flat
            };
            DataGrid_Calculation.Columns.Add(rarityColumn);
            DataGrid_Calculation.CellFormatting += (s, e) =>
            {
                if (DataGrid_Calculation.Columns[e.ColumnIndex].Name == "Rarity" && e.Value is string rarity)
                {
                    e.CellStyle.Font = new Font(DataGrid_Calculation.DefaultCellStyle.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = GetRarityColor(rarity);
                }
            };
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Buy Price", HeaderText = "Buy Price" });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Buy Quantity", HeaderText = "Buy Quantity" });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Sell Price", HeaderText = "Sell Price" });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Sell Quantity", HeaderText = "Sell Quantity" });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Buy Cost", HeaderText = "Total Buy Cost", ReadOnly = true });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Listing Fee", HeaderText = "Total Listing Fee", ReadOnly = true });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Transaction Fee", HeaderText = "Total Transaction Fee", ReadOnly = true });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Fees", HeaderText = "Total Fees", ReadOnly = true });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Revenue", HeaderText = "Total Revenue", ReadOnly = true });
            DataGrid_Calculation.CellFormatting += (s, e) =>
            {
                var colName = DataGrid_Calculation.Columns[e.ColumnIndex].Name;

                if (colName == "Rarity" && e.Value is string rarity)
                {
                    e.CellStyle.Font = new Font(DataGrid_Calculation.DefaultCellStyle.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = GetRarityColor(rarity);
                }

                if ((colName == "Total Profit" || colName == "Profit Margin (%)") && e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.CellStyle.Font = new Font(DataGrid_Calculation.DefaultCellStyle.Font, FontStyle.Bold);
                    if (val < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else if (val > 0)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = DataGrid_Calculation.DefaultCellStyle.ForeColor;
                    }
                }
            };
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total Profit", HeaderText = "Total Profit", ReadOnly = true });
            DataGrid_Calculation.Columns.Add(new DataGridViewTextBoxColumn { Name = "Profit Margin (%)", HeaderText = "Profit Margin (%)", ReadOnly = true });


            // Autoload last CSV data (autosave)
            try
            {
                string autosavePath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "GW2_AuctionHouseCalculator",
                    "autosave.csv"
                );

                if (System.IO.File.Exists(autosavePath))
                {
                    var lines = System.IO.File.ReadAllLines(autosavePath, Encoding.UTF8);
                    if (lines.Length > 0)
                    {
                        int startLine = 0;
                        if (lines[0].Contains("Item Name") && lines[0].Contains("Rarity"))
                            startLine = 1;

                        DataGrid_Calculation.Rows.Clear();

                        for (int i = startLine; i < lines.Length; i++)
                        {
                            var fields = lines[i].Split(';');
                            if (fields.Length < DataGrid_Calculation.Columns.Count)
                                continue; // Skip row if not enough columns

                            int rowIdx = DataGrid_Calculation.Rows.Add();
                            var row = DataGrid_Calculation.Rows[rowIdx];

                            for (int col = 0; col < DataGrid_Calculation.Columns.Count; col++)
                            {
                                row.Cells[col].Value = string.IsNullOrWhiteSpace(fields[col]) ? null : fields[col];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ignore errors when loading to not prevent startup
                Debug.WriteLine($"Error while auto-loading CSV file: {ex.Message}");
            }
        }
        private void Button_Wiki_Click(object sender, EventArgs e)
        {
            string url = "https://wiki.guildwars2.com/";
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the Webiste: {ex.Message}");

            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                saveFileDialog.Title = "CSV-Datei speichern";
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // Header schreiben
                        var header = DataGrid_Calculation.Columns
                            .Cast<DataGridViewColumn>()
                            .Select(col => col.HeaderText.Replace(";", ","));
                        sb.AppendLine(string.Join(";", header));

                        // Zeilen schreiben
                        foreach (DataGridViewRow row in DataGrid_Calculation.Rows)
                        {
                            if (row.IsNewRow) continue;

                            var fields = row.Cells
                                .Cast<DataGridViewCell>()
                                .Select(cell => (cell.Value ?? "").ToString().Replace(";", ","));
                            sb.AppendLine(string.Join(";", fields));
                        }

                        System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("CSV-Datei erfolgreich gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Speichern der CSV-Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Button_Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                openFileDialog.Title = "CSV-Datei laden";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = System.IO.File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);
                        if (lines.Length == 0) return;

                        // Optional: Header prüfen
                        int startLine = 0;
                        if (lines[0].Contains("Item Name") && lines[0].Contains("Rarity"))
                            startLine = 1;

                        DataGrid_Calculation.Rows.Clear();

                        for (int i = startLine; i < lines.Length; i++)
                        {
                            var fields = lines[i].Split(';');
                            if (fields.Length < DataGrid_Calculation.Columns.Count)
                                continue; // Zeile überspringen, wenn zu wenig Spalten

                            int rowIdx = DataGrid_Calculation.Rows.Add();
                            var row = DataGrid_Calculation.Rows[rowIdx];

                            for (int col = 0; col < DataGrid_Calculation.Columns.Count; col++)
                            {
                                // Versuche, leere Felder als null zu setzen
                                row.Cells[col].Value = string.IsNullOrWhiteSpace(fields[col]) ? null : fields[col];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Laden der CSV-Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private Color GetRarityColor(string rarity)
        {
            return rarity switch
            {
                "Junk" => Color.Gray,
                "Basic" => Color.Black,
                "Fine" => Color.Blue,
                "Masterwork" => Color.Green,
                "Rare" => Color.Gold,
                "Exotic" => Color.Orange,
                "Ascended" => Color.HotPink,
                "Legendary" => Color.Purple,
                _ => Color.Black
            };
        }
        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string autosavePath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "GW2_AuctionHouseCalculator",
                    "autosave.csv"
                );

                // Ensure the directory exists
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(autosavePath));

                var sb = new StringBuilder();

                // Write header
                var header = DataGrid_Calculation.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(col => col.HeaderText.Replace(";", ","));
                sb.AppendLine(string.Join(";", header));

                // Write rows
                foreach (DataGridViewRow row in DataGrid_Calculation.Rows)
                {
                    if (row.IsNewRow) continue;

                    var fields = row.Cells
                        .Cast<DataGridViewCell>()
                        .Select(cell => (cell.Value ?? "").ToString().Replace(";", ","));
                    sb.AppendLine(string.Join(";", fields));
                }

                System.IO.File.WriteAllText(autosavePath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Ignore autosave errors to not prevent closing
                Debug.WriteLine($"Autosave error: {ex.Message}");
            }
        }
        private void DataGrid_Calculation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DataGrid_Calculation.Rows)
            {
                if (row.IsNewRow) continue;

                // Werte auslesen und validieren
                bool validBuyPrice = decimal.TryParse(row.Cells["Buy Price"].Value?.ToString(), out decimal buyPrice);
                bool validBuyQty = decimal.TryParse(row.Cells["Buy Quantity"].Value?.ToString(), out decimal buyQty);
                bool validSellPrice = decimal.TryParse(row.Cells["Sell Price"].Value?.ToString(), out decimal sellPrice);
                bool validSellQty = decimal.TryParse(row.Cells["Sell Quantity"].Value?.ToString(), out decimal sellQty);

                if (!(validBuyPrice && validBuyQty && validSellPrice && validSellQty))
                {
                    // Ungültige Werte: Felder leeren
                    row.Cells["Total Buy Cost"].Value = null;
                    row.Cells["Total Listing Fee"].Value = null;
                    row.Cells["Total Transaction Fee"].Value = null;
                    row.Cells["Total Fees"].Value = null;
                    row.Cells["Total Revenue"].Value = null;
                    row.Cells["Total Profit"].Value = null;
                    row.Cells["Profit Margin (%)"].Value = null;
                    continue;
                }

                // Berechnungen
                decimal totalBuyCost = buyPrice * buyQty;
                decimal totalListingFee = sellPrice * sellQty * 0.05m;
                decimal totalTransactionFee = sellPrice * sellQty * 0.15m;
                decimal totalFees = totalListingFee + totalTransactionFee;
                decimal totalRevenue = sellPrice * sellQty * 0.8m;
                decimal totalProfit = totalRevenue - totalBuyCost;
                decimal profitMargin = totalBuyCost != 0 ? (totalProfit / totalBuyCost) * 100 : 0;

                // Ergebnisse eintragen (auf 2 Nachkommastellen runden)
                row.Cells["Total Buy Cost"].Value = Math.Round(totalBuyCost, 2);
                row.Cells["Total Listing Fee"].Value = Math.Round(totalListingFee, 2);
                row.Cells["Total Transaction Fee"].Value = Math.Round(totalTransactionFee, 2);
                row.Cells["Total Fees"].Value = Math.Round(totalFees, 2);
                row.Cells["Total Revenue"].Value = Math.Round(totalRevenue, 2);
                row.Cells["Total Profit"].Value = Math.Round(totalProfit, 2);
                row.Cells["Profit Margin (%)"].Value = Math.Round(profitMargin, 2);
            }
        }
    }
}
