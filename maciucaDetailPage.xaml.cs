using maciuca.Data;
using maciuca.Model;

namespace maciuca;

public partial class maciucaDetailPage : ContentPage
{
    private maciucaDbContext _dbContext;
    public maciucaDetailPage()
	{
		InitializeComponent();
        _dbContext = new maciucaDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "maciuca.db"));
       
    }

   
}

