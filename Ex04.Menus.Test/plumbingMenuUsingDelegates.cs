using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    /// <summary>
    /// Delegates example
    /// </summary>
    public class plumbingMenuUsingDelegates
    {
        public void Run()
        {
            MainMenu m_MainMenu = new MainMenu();
            m_MainMenu.Title = "Main Menu - Plumbing services Using Delegates";

            // first
            MenuItem blockageTechnician = new MenuItem();
            blockageTechnician.Title = "blockage Technician";

            MenuItem blockageInToilet = new MenuItem();
            blockageInToilet.Title = "blockage In Toilet";
            blockageInToilet.MenuAction += new MenuItemActionEventHandler(menuItem_blockageInTheToilet);

            MenuItem blockageInShower = new MenuItem();
            blockageInShower.Title = "blockage In Shower";
            blockageInShower.MenuAction += new MenuItemActionEventHandler(menuItem_blockageInTheShower);

            MenuItem blockageInBath = new MenuItem();
            blockageInBath.Title = "blockage In Bath";
            blockageInBath.MenuAction += new MenuItemActionEventHandler(menuItem_blockageInTheBath);

            blockageTechnician.AddItem(blockageInToilet);
            blockageTechnician.AddItem(blockageInShower);
            blockageTechnician.AddItem(blockageInBath);

            // second
            MenuItem transferTheCall = new MenuItem();
            transferTheCall.Title = "transfer The Call to Receptionist";
            transferTheCall.MenuAction += new MenuItemActionEventHandler(menuItem_talkWithTelephoneReceptionist);

            // third
            MenuItem talkWithManager = new MenuItem();
            talkWithManager.Title = "talk with the manager";

            MenuItem complain = new MenuItem();
            complain.Title = "Complain";

            MenuItem complainOnPlumbingTechnician = new MenuItem();
            complainOnPlumbingTechnician.Title = "complain On Technician";
            complainOnPlumbingTechnician.MenuAction += new MenuItemActionEventHandler(menuItem_complainOnTechnician);

            MenuItem complainOnReceptionist = new MenuItem();
            complainOnReceptionist.Title = "complain On Receptionist";
            complainOnReceptionist.MenuAction += new MenuItemActionEventHandler(menuItem_complainOnTelepohoneReceptionist);

            complain.AddItem(complainOnPlumbingTechnician);
            complain.AddItem(complainOnReceptionist);

            MenuItem justTalkNoComplains = new MenuItem();
            justTalkNoComplains.Title = "just Talk No Complains";
            justTalkNoComplains.MenuAction += new MenuItemActionEventHandler(menuItem_justTalkWithManager);

            talkWithManager.AddItem(complain);
            talkWithManager.AddItem(justTalkNoComplains);

            // forth
            MenuItem thanksFax = new MenuItem();
            thanksFax.Title = "Send thanks fax";
            thanksFax.MenuAction += new MenuItemActionEventHandler(menuItem_sendThanksFax);

            m_MainMenu.AddItem(blockageTechnician);
            m_MainMenu.AddItem(transferTheCall);
            m_MainMenu.AddItem(talkWithManager);
            m_MainMenu.AddItem(thanksFax);

            m_MainMenu.Show();
        }

        private void menuItem_blockageInTheToilet()
        {
            Console.WriteLine("Send toilet technician...");
        }

        private void menuItem_blockageInTheShower()
        {
            Console.WriteLine("Send shower technician...");
        }

        private void menuItem_blockageInTheBath()
        {
            Console.WriteLine("Send bath technician...");
        }

        private void menuItem_talkWithTelephoneReceptionist()
        {
            Console.WriteLine("Transfer a call to Receptionist...");            
        }

        private void menuItem_complainOnTechnician()
        {
            Console.WriteLine("complain on technician...");            
        }

        private void menuItem_complainOnTelepohoneReceptionist()
        {
            Console.WriteLine("complain on telephone receptionist...");
        }

        private void menuItem_justTalkWithManager()
        {
            Console.WriteLine("Transfer a call to Manager...");
        }

        private void menuItem_sendThanksFax()
        {
            Console.WriteLine("Send a Fax...");
        }      
    }
}
