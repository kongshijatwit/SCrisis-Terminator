using UnityEngine;

public class MoreInfoUILinks : MonoBehaviour
{
    public void OnHistoryClicked()
    {
        Application.OpenURL("https://www.sparksicklecellchange.com/sickle-cell-genetics/history?msclkid=b48d293897ca12de18634d0bc97634ba");
    }

    public void OnDonateClicked()
    {
        Application.OpenURL("https://gbscda.org");
    }
}
