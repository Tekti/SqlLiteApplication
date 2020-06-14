using SqlLiteLibrary;
using SqlLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlLite
{
    public partial class PeopleForm : Form
    {
        private List<PersonModel> people = new List<PersonModel>();
        public PeopleForm()
        {
            InitializeComponent();

            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            people = SqlLiteDataAccess.LoadPeople();
            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopeListBox.DataSource = null;
            listPeopeListBox.DataSource = people;
            listPeopeListBox.DisplayMember = "FullName";
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();

            p.FirstName = firstNameTextBox.Text;
            p.LastName = lastNameTextBox.Text;

            SqlLiteDataAccess.SavePerson(p);
            WireUpPeopleList();

            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }
    }
}
