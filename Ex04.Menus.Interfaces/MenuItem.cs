using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private const int k_BackOptionIndex = 0;
        private List<MenuItem> m_MenuItems;
        private IMenuAction m_Action;     
        private string m_BackOption;
        private string m_Title = string.Empty;

        public MenuItem()
        {
            m_BackOption = "Back";
            m_Action = null;
            m_MenuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Add new menu item
        /// </summary>
        /// <param name="i_NewMenuItem"></param>
        public void AddItem(MenuItem i_NewMenuItem)
        {
            m_MenuItems.Add(i_NewMenuItem);
        }

        /// <summary>
        /// Remove item from menu
        /// </summary>
        /// <param name="i_MenuItemToRemove"></param>
        public void RemoveItem(MenuItem i_MenuItemToRemove)
        {
            if (i_MenuItemToRemove != null)
            {
                m_MenuItems.Remove(i_MenuItemToRemove);
            }
        }

        /// <summary>
        /// Display menu on console
        /// </summary>
        public void Show()
        {
            if (IsMenu)
            {
                printMenu();
            }
        }

        private void printMenu()
        {
            bool isExitSelected = false;
            int selectedOption;

            while (!isExitSelected)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(m_Title);
                    printUnderLine(m_Title.Length);
                    for (int menuIdx = 0; menuIdx < m_MenuItems.Count; menuIdx++)
                    {
                        Console.WriteLine("{0}) {1}", menuIdx + 1, m_MenuItems[menuIdx].Title);
                    }

                    Console.WriteLine("{0}) {1}", k_BackOptionIndex, m_BackOption);
                    Console.Write("Your choice: ");
                    bool succeed = int.TryParse(Console.ReadLine(), out selectedOption);
                    if (!succeed)
                    {
                        throw new FormatException("Your choice should be a number");
                    }

                    bool isLegalSelection = validateSelection(selectedOption);
                    if (!isLegalSelection)
                    {
                        throw new ArgumentException("Your choice is out of range");
                    }

                    if (selectedOption == k_BackOptionIndex)
                    {
                        isExitSelected = true;
                    }
                    else
                    {
                        MenuItem selectedMenuItem = m_MenuItems[selectedOption - 1];
                        if (selectedMenuItem.IsMenu)
                        {
                            selectedMenuItem.Show();
                        }
                        else if (selectedMenuItem.m_Action != null)
                        {
                            selectedMenuItem.m_Action.DoAction();
                            Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
                            Console.ReadLine();
                        }
                    }
                }
                catch (FormatException i_FormatException)
                {
                    Console.WriteLine(i_FormatException.Message);
                    Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
                    Console.ReadLine(); 
                }
                catch (ArgumentException i_ArgumentException)
                {
                    Console.WriteLine(i_ArgumentException.Message);
                    Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
                    Console.ReadLine();
                }
            }
        }

        private bool validateSelection(int i_SelectedOption)
        {
            return (i_SelectedOption >= k_BackOptionIndex && i_SelectedOption <= m_MenuItems.Count);
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        public string BackOption
        {
            set
            {
                m_BackOption = value;
            }
        }

        public IMenuAction Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }


        private void printUnderLine(int i_TitleLength)
        {
            for (int i = 0; i < i_TitleLength; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        private bool IsMenu
        {
            get
            {
                return m_MenuItems.Count != 0;
            }
        }
    }
}
