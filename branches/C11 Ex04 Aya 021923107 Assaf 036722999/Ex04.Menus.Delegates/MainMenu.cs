using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_MainMenu;

        public MainMenu()
        {
            m_MainMenu = new MenuItem();
            m_MainMenu.BackOption = "Exit";
        }

        /// <summary>
        /// Display menu on console
        /// </summary>
        public void Show()
        {
            m_MainMenu.Show();
        }

        public string Title
        {
            get
            {
                return m_MainMenu.Title;
            }
            set
            {
                m_MainMenu.Title = value;
            }
        }

        public void AddItem(MenuItem i_NewMenuItem)
        {
            m_MainMenu.AddItem(i_NewMenuItem);
        }

        public void RemoveItem(MenuItem i_MenuItemToRemove)
        {
            m_MainMenu.AddItem(i_MenuItemToRemove);
        }
    }
}
