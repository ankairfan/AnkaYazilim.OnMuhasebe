namespace AnkaYazilim.OnMuhasebe.Blazor.Services;

public class MakbuzHareketService : BaseHareketService<SelectMakbuzHareketDto>, IScopedDependency
{
    public MakbuzService MakbuzService { get; set; }//property injection
    public AppService AppService { get; set; }//property injection

    public override void BeforeUpdate()
    {
        if (MakbuzService.MakbuzTuru == MakbuzTuru.Tahsilat ||
            (SelectedItem.BelgeDurumu != BelgeDurumu.CiroEdildi &&
             SelectedItem.BelgeDurumu != BelgeDurumu.TahsilEdildi))
        {
            DataSource = SelectedItem;
            EditPageVisible = true;
        }
    }
}
