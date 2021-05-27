using System.Collections.Generic;

namespace AtomicSeller.Helpers.Navigation
{
    public class MenuItem
    {
        public const string DefaultIcon = Mdi.ChevronRight;

        public string Label { get; set; }
        /**
         * http://materialdesignicons.com
         */
        public string Icon { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public NavigationHelper.MenuItemsEnum MenuItemEnum { get; set; }
        
        public object HtmlAttributes { get; set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (Parent != null)
                    Parent.IsActive = true;
            }
        }

        public bool IsOpen
        {
            get { return Children.Count > 0 && IsActive; }
        }

        public MenuItem Parent { get; set; }
        public List<MenuItem> Children = new List<MenuItem>();

        private bool _isEnabled;
        public bool Enabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;

                // Disable self & children
                if (!value)
                {
                    Controller = null;
                    Action = null;

                    foreach (var child in Children) child.Enabled = false;
                }
            }
        }


        // ctors
        public static MenuItem NewSection(string label, string icon = DefaultIcon)
        {
            return new MenuItem()
            {
                Label = label,
                Icon = icon,
                Children = new List<MenuItem>(),
                Enabled = true
            };
        }

        public static MenuItem NewItem(NavigationHelper.MenuItemsEnum menuItemEnum, string label, string icon = DefaultIcon, string controller = null, string action = null)
        {
            return new MenuItem()
            {
                MenuItemEnum = menuItemEnum,
                Label = label,
                Icon = icon,
                Controller = controller,
                Action = action,
                Enabled = true
            };
        }


        public void AddChildren(params MenuItem[] items)
        {
            foreach (var item in items)
            {
                item.Parent = this;
                Children.Add(item);
            }
        }

        public void RemoveChild(MenuItem item)
        {
            Children.Remove(item);
        }

        public string GetCSSClasses()
        {
            var classes = "menu-item";

            if (IsActive)
                classes += " active";

            if (IsOpen)
                classes += " open";

            if (!Enabled)
                classes += " disabled";

            return classes;
        }
    }
}
