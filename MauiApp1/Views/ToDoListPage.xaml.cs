using System.Collections.ObjectModel;

namespace MauiApp1.Views;

public class ToDoItem
{
	public string Title { get; set; }
	public string Details { get; set; }
}

public partial class ToDoListPage : ContentPage
{
	ObservableCollection<ToDoItem> tasks = new ObservableCollection<ToDoItem>();

	// A variable to remember which task we are currently editing
	ToDoItem selectedTask = null;

	public ToDoListPage()
	{
		InitializeComponent();

		ToDoListView.ItemsSource = tasks;
	}

	// Handles BOTH Adding and Editing
	private void OnSaveClicked(object sender, EventArgs e)
	{

		if (string.IsNullOrWhiteSpace(TitleEntry.Text))
			return;

		if (selectedTask == null)
		{
			tasks.Add(new ToDoItem
			{
				Title = TitleEntry.Text,
				Details = DetailsEntry.Text
			});
		}
		else
		{
			// Update the existing item
			selectedTask.Title = TitleEntry.Text;
			selectedTask.Details = DetailsEntry.Text;

			int index = tasks.IndexOf(selectedTask);
			tasks.RemoveAt(index);
			tasks.Insert(index, selectedTask);
		}

		ClearInputs();
	}

	// Triggered when you tap a task in the ListView
	private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem is ToDoItem item)
		{
			// Put the selected item's text back into the Entry boxes
			selectedTask = item;
			TitleEntry.Text = item.Title;
			DetailsEntry.Text = item.Details;

			// Change the button text 
			SaveButton.Text = "Update Task";
		}

		((ListView)sender).SelectedItem = null;
	}

	// Triggered by the Delete button
	private void OnDeleteClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var taskToDelete = button.CommandParameter as ToDoItem;

		tasks.Remove(taskToDelete);
		ClearInputs();
	}

	// Triggered by the Clear button
	private void OnClearClicked(object sender, EventArgs e)
	{
		ClearInputs();
	}

	// Helper method to reset the text boxes
	private void ClearInputs()
	{
		TitleEntry.Text = string.Empty;
		DetailsEntry.Text = string.Empty;
		selectedTask = null;
		SaveButton.Text = "Add Task";
	}
}