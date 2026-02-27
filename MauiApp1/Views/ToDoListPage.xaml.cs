using System.Collections.ObjectModel;

namespace MauiApp1.Views;

public partial class ToDoListPage : ContentPage
{
	ObservableCollection<string> tasks = new ObservableCollection<string>();

	public ToDoListPage()
	{
		InitializeComponent();

		TasksCollectionView.ItemsSource = tasks;
	}

	private void OnAddTaskClicked(object sender, EventArgs e)
	{
		// Check if the entry is not empty
		if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
		{
			tasks.Add(TaskEntry.Text);
			TaskEntry.Text = string.Empty;
		}
	}

	private void OnDeleteTaskClicked(object sender, EventArgs e)
	{
		// Figure out which specific 'X' button was clicked
		var button = sender as Button;
		var taskToDelete = button.CommandParameter as string;

		// Remove it from the list
		tasks.Remove(taskToDelete);
	}
}