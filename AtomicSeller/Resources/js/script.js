// Replace all occurences
String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.split(search).join(replacement);
};

Date.prototype.toShortDateString = function () {
    var date = this.getDate(),
        month = this.getMonth() + 1,
        year = this.getFullYear();

    return (date <= 9 ? '0' + date : date) + '/' +
        (month <= 9 ? '0' + month : month) + '/' +
        year;
}

// Default datepicker language
$.extend($.fn.datepicker.defaults,
{
    language: 'globalize',
    weekStart: 1,
    format: 'dd/mm/yyyy',
    todayBtn: false,
    todayHighlight: true
});

// AutoNumeric
$.extend($.fn.autoNumeric.defaults,
{
    aSep: ' ',
    aDec: ',',
    altDec: '.',
    pSign: 's'
});

// Mask
$.mask.autoclear = false;

$.fn.fadeInOrOut = function (status) {
    return status ? this.fadeIn() : this.fadeOut();
}

$(document).ready(function () {
    if (!$('body').is('.page-login')) {
        // Menu latéral
        $('nav').drawer();

        // Tablesorters
        $('.table:not(.sorter-false)').each(function() {
            var options = {
                dateFormat: 'uk',
                sortReset: true
            };

            if ($(this).is('.filter-true')) {
                var table = $(this);

                // Add filter button to panel
                if (!!$(this).closest('.panel').length) {
                    $('<i />')
                        .attr('data-toggle', 'tooltip')
                        .attr('data-placement', 'left')
                        .attr('title', 'Filtrer')
                        .addClass('mdi mdi-filter pull-right')
                        .click(function () {
                            $(this)
                                .toggleClass('mdi-filter')
                                .toggleClass('mdi-filter-outline');

                            table.find('.tablesorter-filter-row').toggle();
                            table.find('.input-sm:first').focus();
                        })
                        .appendTo($(this).closest('.panel').find('.panel-heading'));
                }

                options = $.extend(options, {
                    widthFixed: true,
                    cssChildRow: "tablesorter-childRow",
                    widgets: ['filter'],
                    widgetOptions: {
                        filter_cssFilter: 'form-control input-sm',
                        filter_placeholder: { search: 'Filtrer…', select: '' },
                        filter_childRows: false
                    }
                });
            }

            $(this).tablesorter(options);
        });
        $('.table:not(.sorter-false)').tablesorter({
            dateFormat: 'uk',
            sortReset: true
        });

        // AutoNumeric
        $('[data-autonumeric]').each(function (i, elem) {
            var options = {};

            if ($(this).is('[data-type="Currency"]'))
                options.aSign = ' €';

            $(elem).autoNumeric('init', options);
        });
    }
    
    // Callouts
    $('.bs-close').click(function() {
        $(this).closest('.bs-callout').slideUp();
    });

    // Init file pickers
    $(':file').on('fileselect', function (event, numFiles, label) {
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' fichiers sélectionnés' : label;

        if (input.length)
            input.val(log);
    });

    // Datepickers
    $('.datepicker').each(function() {
        var minDate = $(this).data('date-min'),
            maxDate = $(this).data('date-max');

        var options = {
            language: 'fr',
            enableOnReadonly: false
        };

        if (minDate !== "")
            options['startDate'] = new Date(minDate);
        if (maxDate !== "")
            options['endDate'] = new Date(maxDate);

        $(this).datepicker(options);

        $('<i/>').addClass('mdi mdi-calendar').insertAfter($(this));
    });
    
    // Confirmations
    $('.confirmation[data-message]').confirm();

    // Handle form submitting for AutoNumeric
    $('form').submit(function () {
        $('input').each(function() {
            var self = $(this);

            try {
                var v = self.autoNumeric('get');
                self.autoNumeric('destroy');

                // Update format (dd.dd => dd,dd)
                v = v.replaceAll('.', ',');

                self.val(v);
            } catch(err) {
                // Not an autonumeric field
            }
        });

        return true;
    });

    // Tooltips
    $('[data-toggle="tooltip"]').tooltip({
        container: 'body',
        animation: false
    });

    // Togglable panels
    $('.panel-togglable').find('.panel-heading').click(function() {
        $(this)
            .parent().toggleClass('panel-togglable-closed')
            .children().filter(':not(.panel-heading)').slideToggle();
    });
    $('.panel-closed').find('.panel-heading').click();

    // Pagination: init links
    $('.pagination-wrap').find('[data-page]').each(function() {
        $(this).attr('href', Utils.updateQueryString('page', $(this).data('page')));
    });

    // Mask on datepickers
    Forms.initMask($('input.datepicker'), '99/99/9999', false);

    $('.forceStopLoading').click(function () {
        setTimeout(function () { Utils.setIsLoading(false); }, 2000);
    });

    $('.filterable').find('.mdi-filter').click();
});

// Display loading animation on page unload...
window.onbeforeunload = function () {
    Utils.setIsLoading(true);
};
// ... and on every ajax request
$.ajaxSetup({
    beforeSend: function() {
        Utils.setIsLoading(true);
    },
    complete: function() {
        Utils.setIsLoading(false);
    }
});
