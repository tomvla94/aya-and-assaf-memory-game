using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class plumbingMenuUsingInterfaces
    {
        public void Run()
        {
            MainMenu m_MainMenu = new MainMenu();
            m_MainMenu.Title = "Main Menu - Plumbing services Using Interfaces";

            #region MenuItems
            #region First
            MenuItem blockageTechnician = new MenuItem();
            blockageTechnician.Title = "blockage Technician";

            MenuItem blockageInToilet = new MenuItem();
            blockageInToilet.Title = "blockage In Toilet";
            blockageInToilet.Action = new BlockageInTheToilet();

            MenuItem blockageInShower = new MenuItem();
            blockageInShower.Title = "blockage In Shower";
            blockageInShower.Action = new BlockageInTheShower();

            MenuItem blockageInBath = new MenuItem();
            blockageInBath.Title = "blockage In Bath";
            blockageInBath.Action = new BlockageInTheBath();

            blockageTechnician.AddItem(blockageInToilet);
            blockageTechnician.AddItem(blockageInShower);
            blockageTechnician.AddItem(blockageInBath);

            #endregion First

            #region Second

            MenuItem transferTheCall = new MenuItem();
            transferTheCall.Title = "transfer The Call to Receptionist";
            transferTheCall.Action = new TalkWithTelephoneReceptionist();

            #endregion Second

            #region Third

            MenuItem talkWithManager = new MenuItem();
            talkWithManager.Title = "talk with the manager";

            MenuItem complain = new MenuItem();
            complain.Title = "Complain";

            MenuItem complainOnTechnician = new MenuItem();
            complainOnTechnician.Title = "complain On Technician";
            complainOnTechnician.Action = new ComplainOnTechnician();

            MenuItem complainOnReceptionist = new MenuItem();
            complainOnReceptionist.Title = "complain On Receptionist";
            complainOnReceptionist.Action = new ComplainOnTelephoneReceptionist();

            complain.AddItem(complainOnTechnician);
            complain.AddItem(complainOnReceptionist);

            MenuItem justTalkNoComplains = new MenuItem();
            justTalkNoComplains.Title = "just Talk No Complains";
            justTalkNoComplains.Action = new TalkWithManager();

            talkWithManager.AddItem(complain);
            talkWithManager.AddItem(justTalkNoComplains);

            #endregion Third

            #region Forth

            MenuItem thanksFax = new MenuItem();
            thanksFax.Title = "Send thanks fax";
            thanksFax.Action = new SendThanksFax();
            
            #endregion Forth
            #endregion MenuItems

            m_MainMenu.AddItem(blockageTechnician);
            m_MainMenu.AddItem(transferTheCall);
            m_MainMenu.AddItem(talkWithManager);
            m_MainMenu.AddItem(thanksFax);

            m_MainMenu.Show();
            
        }


        class BlockageInTheToilet : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Send toilet technician...");
            }

            #endregion
        }

        class BlockageInTheShower : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Send shower technician...");
            }

            #endregion
        }

        class BlockageInTheBath : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Send bath technician...");
            }

            #endregion
        }

        class ComplainOnTechnician : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("complain on technician...");
            }

            #endregion
        }

        class ComplainOnTelephoneReceptionist : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("complain on telephone receptionist...");
            }

            #endregion
        }

        class TalkWithTelephoneReceptionist : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Transfer a call to Receptionist...");
            }

            #endregion
        }

        class TalkWithManager : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Transfer a call to Manager...");
            }

            #endregion
        }

        class SendThanksFax : IMenuAction
        {
            #region IMenuAction Members

            public void DoAction()
            {
                Console.WriteLine("Send a Fax...");
            }

            #endregion
        }
    }
}
