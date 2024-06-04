namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
    string UserInput = "adhjda";
    string CurrentAction = "Add";
    int EditIndex;
    string EditItem;
    List
<string> TodoData = new List
    <string>();
    public NewPage1()
    {
        InitializeComponent();
    }
    private void OnSubmit(object sender, EventArgs e)
    {
       
        if (CurrentAction == "Add")
        {
            UserInput = AddTodo.Text;
            UserLabel.Text = UserInput;
            TodoData.Add(UserInput);
            ListViewXAML.ItemsSource = null;
            ListViewXAML.ItemsSource = TodoData;
            AddTodo.Text = "";

        }
        else 
        {

            TodoData[EditIndex] = AddTodo.Text;
            CurrentAction = "Add";
            Sub.Text = "Submit";
            ListViewXAML.ItemsSource = null;
            ListViewXAML.ItemsSource= TodoData;
            AddTodo.Text = "";

        }

    }
    private void OnItemDelete(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
        {
            ErrorLabel.Text = "No item is selected";
        }
        else
        {
            // Get the tapped item
            string tappedItem = e.SelectedItem.ToString();

            int tappedIndex = -1;
            for (int i = 0; i
            < TodoData.Count; i++)
            {
                if (TodoData[i] == tappedItem)
                {
                    tappedIndex = i;
                    break; // Exit the loop once the index is found
                }
            }
            TodoData.Remove(tappedItem);
            ListViewXAML.ItemsSource = null;
            ListViewXAML.ItemsSource = TodoData;
            ErrorLabel.Text = tappedIndex >= 0 ? tappedIndex.ToString() : "Index not found";
        }
    }

    private async void ReturnHome(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private void OnEditClicked(object sender, EventArgs e)
{
    Button button = (Button)sender;
        EditItem = (string)button.CommandParameter;

    EditIndex = TodoData.IndexOf(EditItem);
    // Use the index as needed
    ErrorLabel.Text = $"Index of item '{EditItem}' is: {EditIndex}";
        CurrentAction = "Edit";
        AddTodo.Text = EditItem;
        Sub.Text = "Edit";
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string item = (string)button.CommandParameter;

        int index = TodoData.IndexOf(item);
        TodoData.Remove(item);
        ListViewXAML.ItemsSource = null;
        ListViewXAML.ItemsSource= TodoData;
        ErrorLabel.Text = $"{item} {index}";
    }
}