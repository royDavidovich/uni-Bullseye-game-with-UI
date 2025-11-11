namespace Ex05.UI
{
    public class Program
    {
        public static void Main()
        {
            ChancesSelectionForm chancesSelectionForm = new ChancesSelectionForm();
            
            chancesSelectionForm.ShowDialog();
            if (chancesSelectionForm.ClosedByStart)
            {
                BoolPgia boolPgia = new BoolPgia(chancesSelectionForm);
                
                boolPgia.ShowDialog();
            }
        }
    }
}