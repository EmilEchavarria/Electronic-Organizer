using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer;
using FeatureLayer;

namespace ElectronicOrganizer
{
    public partial class FrmCategoria : Form
    {
        private Business businessLayer;

        public FrmCategoria()
        {
            InitializeComponent();
            businessLayer = new Business(); // Instance of BusinessLayer
        }

        // Form load event
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            // Ensure columns are configured before adding rows
            if (DgvM.Columns.Count == 0)
            {
                DgvM.Columns.Add("Id", "ID");
                DgvM.Columns.Add("FirstName", "First Name");
                DgvM.Columns.Add("LastName", "Last Name");
                DgvM.Columns.Add("BirthDate", "Birth Date");
                DgvM.Columns.Add("Address", "Address");
                DgvM.Columns.Add("Gender", "Gender");
                DgvM.Columns.Add("MaritalStatus", "Marital Status");
                DgvM.Columns.Add("Mobile", "Mobile");
                DgvM.Columns.Add("Phone", "Phone");
                DgvM.Columns.Add("Email", "Email");
            }
        }

        // Insert button event
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Create Feature object with form values
                Feature newPerson = new Feature
                {
                    FirstName = TxtName.Text,
                    LastName = TxtSurname.Text,
                    BirthDate = DateTime.Parse(TxtBirth.Text),
                    Address = TxtAddress.Text,
                    Gender = CbGender.Text,
                    MaritalStatus = CbMaritalStatus.SelectedItem.ToString(),
                    Mobile = TxtMobile.Text,
                    Phone = TxtPhone.Text,
                    Email = TxtEmail.Text
                };

                // Call Insert method in business layer
                businessLayer.Insert(newPerson);

                // Confirmation message
                MessageBox.Show("Record inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search by ID button event
        private void BtnSearchID_Click(object sender, EventArgs e)
        {
            // Validate that the ID is an integer
            if (int.TryParse(TxtSearchID.Text, out int id))
            {
                // Search by ID using business layer
                Feature result = businessLayer.SearchById(id);

                if (result != null)
                {
                    // Display data in corresponding TextBoxes
                    TxtNameM.Text = result.FirstName;
                    TxtSurnameM.Text = result.LastName;
                    TxtBirthM.Text = result.BirthDate.ToShortDateString();
                    TxtAddressM.Text = result.Address;
                    CbGenderM.Text = result.Gender;
                    CbMaritalStatusM.Text = result.MaritalStatus;
                    TxtMobileM.Text = result.Mobile;
                    TxtPhoneM.Text = result.Phone;
                    TxtEmailM.Text = result.Email;

                    // Ensure columns are configured before adding rows
                    if (DgvM.Columns.Count == 0)
                    {
                        DgvM.Columns.Add("Id", "ID");
                        DgvM.Columns.Add("FirstName", "First Name");
                        DgvM.Columns.Add("LastName", "Last Name");
                        DgvM.Columns.Add("BirthDate", "Birth Date");
                        DgvM.Columns.Add("Address", "Address");
                        DgvM.Columns.Add("Gender", "Gender");
                        DgvM.Columns.Add("MaritalStatus", "Marital Status");
                        DgvM.Columns.Add("Mobile", "Mobile");
                        DgvM.Columns.Add("Phone", "Phone");
                        DgvM.Columns.Add("Email", "Email");
                    }

                    // Clear any previous rows
                    DgvM.Rows.Clear();

                    // Add a new row with the obtained data
                    DgvM.Rows.Add(
                        result.Id,
                        result.FirstName,
                        result.LastName,
                        result.BirthDate.ToShortDateString(),
                        result.Address,
                        result.Gender,
                        result.MaritalStatus,
                        result.Mobile,
                        result.Phone,
                        result.Email
                    );
                }
                else
                {
                    MessageBox.Show("No record found with that ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modify button event
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the ID of the record to modify (you can use the ID already in the TextBoxes or in a hidden field)
                int id = Convert.ToInt32(TxtSearchID.Text);

                // Create Feature object with modified form values
                Feature modifiedPerson = new Feature
                {
                    Id = id,
                    FirstName = TxtNameM.Text,
                    LastName = TxtSurnameM.Text,
                    BirthDate = DateTime.Parse(TxtBirthM.Text),
                    Address = TxtAddressM.Text,
                    Gender = CbGenderM.Text,
                    MaritalStatus = CbMaritalStatusM.SelectedItem.ToString(),
                    Mobile = TxtMobileM.Text,
                    Phone = TxtPhoneM.Text,
                    Email = TxtEmailM.Text
                };

                // Call Edit method in business layer
                businessLayer.Edit(modifiedPerson);

                // Confirmation message
                MessageBox.Show("Record modified successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modifying: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search by name button event
        private void BtnSearchName_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the entered name
                string name = TxtSearchName.Text.Trim();

                if (!string.IsNullOrEmpty(name))
                {
                    // Search by name using business layer
                    List<Feature> results = businessLayer.SearchByName(name);

                    if (results != null && results.Count > 0)
                    {
                        // Clear any previous rows in the DataGridView
                        DgvB.Rows.Clear();

                        // Clear existing columns
                        DgvB.Columns.Clear();

                        // Add columns dynamically based on Feature class properties
                        DgvB.Columns.Add("Id", "ID");
                        DgvB.Columns.Add("FirstName", "First Name");
                        DgvB.Columns.Add("LastName", "Last Name");
                        DgvB.Columns.Add("BirthDate", "Birth Date");
                        DgvB.Columns.Add("Address", "Address");
                        DgvB.Columns.Add("Gender", "Gender");
                        DgvB.Columns.Add("MaritalStatus", "Marital Status");
                        DgvB.Columns.Add("Mobile", "Mobile");
                        DgvB.Columns.Add("Phone", "Phone");
                        DgvB.Columns.Add("Email", "Email");

                        // Add rows with obtained results
                        foreach (var result in results)
                        {
                            DgvB.Rows.Add(
                                result.Id,
                                result.FirstName,
                                result.LastName,
                                result.BirthDate.ToShortDateString(),
                                result.Address,
                                result.Gender,
                                result.MaritalStatus,
                                result.Mobile,
                                result.Phone,
                                result.Email
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No records found with that name.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a name to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search by ID for deletion button event
        private void BtnSearchIdE_Click(object sender, EventArgs e)
        {
            // Validate that the entered ID is an integer
            if (int.TryParse(TxtSearchIdE.Text, out int id))
            {
                // Search by ID using business layer
                Feature result = businessLayer.SearchById(id);

                if (result != null)
                {
                    // Check if columns are already configured
                    if (DgvE.Columns.Count == 0)
                    {
                        // Configure DgvE columns if not defined
                        DgvE.Columns.Add("Id", "ID");
                        DgvE.Columns.Add("FirstName", "First Name");
                        DgvE.Columns.Add("LastName", "Last Name");
                        DgvE.Columns.Add("BirthDate", "Birth Date");
                        DgvE.Columns.Add("Address", "Address");
                        DgvE.Columns.Add("Gender", "Gender");
                        DgvE.Columns.Add("MaritalStatus", "Marital Status");
                        DgvE.Columns.Add("Mobile", "Mobile");
                        DgvE.Columns.Add("Phone", "Phone");
                        DgvE.Columns.Add("Email", "Email");
                    }

                    // Clear any previous rows
                    DgvE.Rows.Clear();

                    // Add a new row with the obtained data
                    DgvE.Rows.Add(
                        result.Id,
                        result.FirstName,
                        result.LastName,
                        result.BirthDate.ToShortDateString(),
                        result.Address,
                        result.Gender,
                        result.MaritalStatus,
                        result.Mobile,
                        result.Phone,
                        result.Email
                    );
                }
                else
                {
                    MessageBox.Show("No record found with that ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete button event
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Validate that the entered ID is an integer
            if (int.TryParse(TxtSearchIdE.Text, out int id))
            {
                // Search by ID using business layer
                Feature result = businessLayer.SearchById(id);

                if (result != null)
                {
                    // Check if the CheckBox is checked
                    if (CheckBox.Checked) // Check if the CheckBox is checked
                    {
                        // Call Deactivate method to delete the record
                        businessLayer.Deactivate(id);

                        // Show success message
                        MessageBox.Show("Record deactivated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear fields after deletion
                        TxtSearchIdE.Clear();
                        CheckBox.Checked = false; // Uncheck the CheckBox
                                                  // Clear the DataGridView if necessary
                        DgvE.Rows.Clear();
                    }
                    else
                    {
                        // Show message if the CheckBox is not checked
                        MessageBox.Show("Please check the CheckBox before deleting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No record found with that ID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            // Check if columns already exist, if not, add them
            if (DgvA.Columns.Count == 0)
            {
                DgvA.Columns.Add("Id", "ID");
                DgvA.Columns.Add("FirstName", "First Name");
                DgvA.Columns.Add("LastName", "Last Name");
                DgvA.Columns.Add("BirthDate", "Birth Date");
                DgvA.Columns.Add("Address", "Address");
                DgvA.Columns.Add("Gender", "Gender");
                DgvA.Columns.Add("MaritalStatus", "Marital Status");
                DgvA.Columns.Add("Mobile", "Mobile");
                DgvA.Columns.Add("Phone", "Phone");
                DgvA.Columns.Add("Email", "Email");
            }
        }

        // Search all inactive records button event
        private void BtnSearchAll_Click(object sender, EventArgs e)
        {
            // Call method to initialize columns before adding rows
            InitializeDataGridView();

            // Create an instance of the business layer
            Business businessLayer = new Business();

            // Get inactive records from the business layer
            List<Feature> inactiveRecords = businessLayer.GetInactiveRecords();

            // Clear the DataGridView before adding new data
            DgvA.Rows.Clear();

            // Check if there are inactive records
            if (inactiveRecords.Count > 0)
            {
                // Fill the DataGridView with inactive records
                foreach (var record in inactiveRecords)
                {
                    // Add each record as a new row in the DataGridView
                    DgvA.Rows.Add(
                        record.Id,
                        record.FirstName,
                        record.LastName,
                        record.BirthDate.ToShortDateString(),
                        record.Address,
                        record.Gender,
                        record.MaritalStatus,
                        record.Mobile,
                        record.Phone,
                        record.Email
                    );
                }
            }
            else
            {
                // If no inactive records, show a message to the user
                MessageBox.Show("No inactive records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Activate record button event
        private void BtnActive_Click(object sender, EventArgs e)
        {
            // Validate if the ID is valid
            if (int.TryParse(TxtActive.Text, out int id))
            {
                // Check if the CheckBox is checked
                if (CheckBoxA.Checked)
                {
                    // Create an instance of the business layer
                    Business businessLayer = new Business();

                    // Call the business layer method to activate the record with the ID
                    businessLayer.Activate(id);

                    // Show success message
                    MessageBox.Show("Record activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please check the checkbox to activate the record.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // If the entered ID is not valid
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
