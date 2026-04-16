private void btnSave_Click(object sender, RoutedEventArgs e)
{
    var newLog = new FlightLog
    {
        OriginICAO = txtOrigin.Text,
        DestinationICAO = txtDestination.Text,
        DurationMinutes = int.Parse(txtDuration.Text),
        FlightDate = dpDate.SelectedDate ?? DateTime.Now,
        Takeoffs = 1,
        Landings = 1
    };

    var db = new DatabaseHelper();
    db.AddFlightLog(newLog);

    MessageBox.Show("Flight recorded successfully!");
    this.Close();
}