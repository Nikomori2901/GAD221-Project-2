using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPhase : MonoBehaviour
{
    private TMP_Text _emailtext;
    private Button _button;
    
    public List<string> emails = new List<string>()
    {
        // Email 1
        "Hey Everyone,\n\n" +
        "Just checking in on your first couple of weeks at the studio.\n" +
        "I’m to notify you on the allocation of funding. You’ll have to split it to a select few amongst your teams. Apart from that, no pressure, work as you’ll normally do and if stuff gets too much, ordering pizza every once in a while for the team helps take a breather.\n\n" +
        "Anyway, we’re looking to launch maybe late Q1 next year and the board is thinking maybe you and your team will have a prototype ready in three months' time. So, I’d say things are progressing according to schedule, so no stress! Also, before I forget. I’m leaving you in charge of employee recruitment for the team. Just remember to pick the right person for the right job!\n\n" +
        "Sincerely, Publisher CEO",
        
        // Email 2
        "Hey Everyone,\n\n" +
        "Just to inform you, that some funding will have to be moved elsewhere to our marketing department, you understand right? They’re going to need some of the financial help if we are ever to get this game in the hands of our target audience. Also, remember about the prototype? Yeah, me and the rest of the board were thinking if you can get it ready a month early. I get this will be a bummer for team spirit but you can power through this right? You got this!\n\n" +
        "Sincerely, Publisher CEO"
        
        // Email 3
        
        
        // Email 4
        
    };
    
    void Start()
    {
        _emailtext = GetComponentInChildren<TMP_Text>();
        _button = GetComponentInChildren<Button>();

        SetText(1);
    }

    public void SetText(int stage)
    {
        switch (stage)
        {
            case 1:
                _emailtext.text = emails[0];
                break;
            case 2:
                _emailtext.text = emails[1];
                break;
            case 3:
                _emailtext.text = emails[2];
                break;
            case 4:
                _emailtext.text = emails[3];
                break;
        }
    }
}
