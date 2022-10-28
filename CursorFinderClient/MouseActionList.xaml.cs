using CursorFinderClient.CursorFinderService;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CursorFinderClient.Windows
{
    /// <summary>
    /// Interaction logic for MouseActionList.xaml
    /// </summary>
    public partial class MouseActionList : Window
    {
        public List<CursorPosition> CursorPositions { get; set; }

        public MouseActionList(List<CursorPosition> positions)
        {
            InitializeComponent();
            CursorPositions = positions;
            DataContext = this;
        }
    }


}
