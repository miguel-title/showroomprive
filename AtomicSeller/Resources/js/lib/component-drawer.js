/**
 * Caisse des Congés Payés - Extranet V4
 * Composant Javascript - Drawer (menu latéral)
 */

(function ($, window) {
    var Drawer = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    Drawer.prototype = {
        defaults: {
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            this.menuItems = this.elem.find('.menu-item');
            this.menuSubItems = this.menuItems.find('a');
            
            // Update active item on click
            this.menuSubItems.click(function () {
                menuSubItems.removeClass('active');
                $(this).addClass('active');
            });

            // Toggle submenus visibility on parent click
            this.menuItems.click(function (e) {
                if ($(this).is('.disabled'))
                    return;

                // If that's a footer link, just open it
                if (!$(this).is('a[href="#"]'))
                    return;

                e.preventDefault();
                var openedMenuItem = self.menuItems.filter('.open');

                // Close currently open menuItem
                self.toggleItem(openedMenuItem);

                if (!openedMenuItem.is($(this)))
                    self.toggleItem($(this));
            });

            // Responsive mode: toggle
            var body = $('body');
            var navMask = $('.nav-fullmask').click(function () {
                body.removeClass('nav-shown')
                    .addClass('nav-hidden');
                navMask.fadeOut(300);
            });
            $('header').find('.toggle-menu').click(function (e) {
                e.preventDefault();

                var isMobile = window.matchMedia('only screen and (max-width: 767px)').matches;
                
                // First click
                if (!body.is('.nav-shown') && !body.is('.nav-hidden'))
                    body.addClass(isMobile ? 'nav-shown' : 'nav-hidden');
                else {
                    body.toggleClass('nav-shown')
                        .toggleClass('nav-hidden');
                }

                if (isMobile)
                    navMask.fadeIn(300);
            });
        },

        /**
         * Toggles visibility for this menu element's child items
         */
        toggleItem: function(menuItem) {
            menuItem
                .toggleClass('open');

            menuItem.closest('li').find('ul').slideToggle(200);
        }
    };


    Drawer.defaults = Drawer.prototype.defaults;

    $.fn.drawer = function(options) {
        return new Drawer(this.first(), options).init();
    };

    window.Drawer = Drawer;
}(jQuery, window));
