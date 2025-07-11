using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelephoneApp.Business;
using TelephoneApp.DataAccess;
using TelephoneApp.Entitiy;

namespace TelephoneApp
{
    public partial class Form1 : Form
    {
        private ContactService _contactService;
        public Form1()
        {
            InitializeComponent();
            IContactRepository repo = new ContactRepository();
            _contactService = new ContactService(repo);

            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = _contactService.GetAllContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                Isim = txtIsim.Text,
                Soyisim = txtSoyisim.Text,
                Numara = txtNumara.Text,
                Cinsiyet = cmbCinsiyet.SelectedItem?.ToString(),
                Mail = txtMail.Text
            };
            _contactService.AddContact(contact);
            LoadData();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            var contact = new Contact
            {
                Id = id,
                Isim = txtIsim.Text,
                Soyisim = txtSoyisim.Text,
                Numara = txtNumara.Text,
                Cinsiyet = cmbCinsiyet.SelectedItem?.ToString(),
                Mail = txtMail.Text
            };
            _contactService.UpdateContact(contact);
            LoadData();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            _contactService.DeleteContact(id);
            LoadData();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtIsim.Clear();
            txtSoyisim.Clear();
            txtNumara.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            txtMail.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            txtIsim.Text = dataGridView1.CurrentRow.Cells["Isim"].Value?.ToString();
            txtSoyisim.Text = dataGridView1.CurrentRow.Cells["Soyisim"].Value?.ToString();
            txtNumara.Text = dataGridView1.CurrentRow.Cells["Numara"].Value?.ToString();
            cmbCinsiyet.SelectedItem = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value?.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value?.ToString();
            dataGridView1.ReadOnly = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            var filteredContacts = _contactService.SearchContacts(search);
            dataGridView1.DataSource = filteredContacts;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Çıkış işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
