/**
 * Caisse des Congés Payés - Extranet V4
 * Composant Javascript - Confirm
 */

(function ($, window) {
    var Confirm = function(elem, options) {
        this.elem = elem;
        this.options = options;
    };

    Confirm.prototype = {
        defaults: {
            message: null,
            action: null
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);
            
            this.settings.message = this.settings.message || this.elem.data('message');
            this.settings.action = this.settings.action || this.elem.data('action') || this.elem.attr('href');

            this.elem.attr('href', '#');
            this.dialog = $('#confirmModal');

            this.elem.click(function(e) {
                e.preventDefault();

                self.showConfirmDialog();
            });
        },

        showConfirmDialog: function () {
            this.dialog.find('.modal-body-content').find('span').text(this.settings.message);
            this.dialog.find('.modal-confirm-button').attr('href', this.settings.action);
            this.dialog.modal('show');
        },

        closeConfirmDialog: function() {
            this.dialog.modal('hide');
        }
    };


    Confirm.defaults = Confirm.prototype.defaults;

    $.fn.confirm = function (options) {
        this.each(function() {
            new Confirm($(this), options).init();
        });
    };

    window.Confirm = Confirm;
}(jQuery, window));
