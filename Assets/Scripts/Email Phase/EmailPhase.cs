using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPhase : MonoBehaviour
{
    private TMP_Text _emailtext;
    private Button _button;
    private List<string> _emails = new List<string>();
    
    void Start()
    {
        _emailtext = GetComponentInChildren<TMP_Text>();
        _button = GetComponentInChildren<Button>();
        
        _emails.Add // Email 1
            (
                "Hey Everyone,\n\n" +
                "Just checking in on your first couple of weeks at the studio.\n" +
                "I’m to notify you on the allocation of funding. You’ll have to split it to a select few amongst your teams. Apart from that, no pressure, work as you’ll normally do and if stuff gets too much, ordering pizza every once in a while for the team helps take a breather.\n\n" +
                "Anyway, we’re looking to launch maybe late Q1 next year and the board is thinking maybe you and your team will have a prototype ready in three months' time. So, I’d say things are progressing according to schedule, so no stress! Also, before I forget. I’m leaving you in charge of employee recruitment for the team. Just remember to pick the right person for the right job!\n\n" +
                "Sincerely, Publisher CEO"
            );
        
        _emails.Add // Email 2
            (
                "Hey Everyone,\n\n" +
                "Just to inform you, that some funding will have to be moved elsewhere to our marketing department, you understand right? They’re going to need some of the financial help if we are ever to get this game in the hands of our target audience. Also, remember about the prototype? Yeah, me and the rest of the board were thinking if you can get it ready a month early. I get this will be a bummer for team spirit but you can power through this right? You got this!\n\n" +
                "Sincerely, Publisher CEO"
            );
        
        _emails.Add // Email 3
            (
                "Hey Everyone,\n\n" +
                "So good news and bad news. Good news is, we were able to secure a high-profile celebrity to do the voice acting for the main protagonist. Exciting, right! I can’t believe it either! Which brings us to the bad news, we need to allocate more of our funds for the celebrity’s paycheck. Look, I know. Your team isn’t going to like it, but this always happens with this line of work. But hey, no pain, no gain right?\n\n" +
                "Sincerely, Publisher CEO"
            );
        
        _emails.Add // Email 4
            (
                "Hey Everyone,\n\n" +
                "So the board was thinking that maybe Q1 next year isn’t the best time to ship. With all the competing titles in that quarter, we don’t think it’s doable. We were thinking of Christmas this year. So, I need you and your team in overdrive mode now! Also, we were thinking. All those extra modes and testing phases for the game, we don’t think the’re necessary. So we figure, it’s probably in the best interest to keep the budget low. You understand, right? \n\n" +
                "Now I get that you and your team have had your ups and downs during this whole development process, but you can survive right? Oh yeah, I should probably mention, some complaints have been circling around the office and I’m starting to suspect that everyone is sick of pizza right now, so I’d say your little pizza parties are a no go.\n\n" +
                "Sincerely, Publisher CEO"
            );

        SetText(4);
    }

    public void SetText(int stage)
    {
        switch (stage)
        {
            case 1:
                _emailtext.text = _emails[0];
                break;
            case 2:
                _emailtext.text = _emails[1];
                break;
            case 3:
                _emailtext.text = _emails[2];
                break;
            case 4:
                _emailtext.text = _emails[3];
                break;
        }
    }

    public void NextDayButtonPress()
    {
        PhaseManager.instance.NextPhase();
    }
}
