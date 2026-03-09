using Crud2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud2._0
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        /// Loads all categories from the database and displays them in the DataGridView.
        private void LoadCategories()
        {
            dgvCategories.DataSource = CategoryDAL.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category c = new Category
            {
                Name = txtName.Text.Trim(), // Trim whitespace from the name.
                Description = txtDescription.Text.Trim() // Trim whitespace from the description.
            };
            CategoryDAL.Insert(c); // Inserts the new category into the database.
            LoadCategories(); // Reloads the categories to update the DataGridView.
            ClearForm(); // Clears the input fields.
        }
        /// Handles the click event for the Update button, updating an existing category in the database.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["category_id"].Value);
                Category c = new Category
                {
                    CategoryID = id,
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };
                CategoryDAL.Update(c); // Updates the category in the database.
                LoadCategories(); // Reloads categories.
                ClearForm(); // Clears input fields.
            }

        }
        /// Handles the click event for the Delete button, deleting a selected category from the database.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Checks if a row is currently selected.
            if (dgvCategories.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["category_id"].Value);
                CategoryDAL.Delete(id);
                LoadCategories();
                ClearForm();
            }

        }
        /// Clears the text from the Name and Description input fields.
        public void ClearForm()
        {
            txtDescription.Text = "";
            txtName.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void dgvCategories_SelectedChanged(object sender, EventArgs e)
        {
            // Ensures a valid row is selected and it's not a new row for data entry.
            if (dgvCategories.CurrentRow != null && dgvCategories.CurrentRow.Index >= 0 && !dgvCategories.CurrentRow.IsNewRow)
            {
                // Populates the text boxes with the name and description from the selected row.
                txtName.Text = dgvCategories.CurrentRow.Cells["name"].Value?.ToString();
                txtDescription.Text = dgvCategories.CurrentRow.Cells["description"].Value?.ToString();
            }
        }
    }
}
