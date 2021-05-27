/**
 * Caisse des Congés Payés - Extranet V4
 * Lib forms
 */

window.Forms = {
    initMask: function (element, mask, stripNonNumericCharsOnSubmit) {
        stripNonNumericCharsOnSubmit = typeof stripNonNumericCharsOnSubmit !== 'undefined' ? stripNonNumericCharsOnSubmit : true;
        element.mask(mask);

        if (element.attr('placeholder') === undefined)
            element.attr('placeholder', mask.replace(/\d/g, '_'));

        // On form submit, strip all non-numeric chars from value
        if (stripNonNumericCharsOnSubmit) {
            element.closest('form').submit(function() {
                element.val(element.val().replace(/\D/g, ''));

                return true;
            });
        }
    },

    destroyAutonumeric: function (elem) {
        if (!elem.is('[data-autonumeric]'))
            return;

        var val = elem.val();
        elem.autoNumeric('destroy');
        elem.removeAttr('data-autonumeric');
        //elem.off('.autoNumeric'); fixed in https://github.com/BobKnothe/autoNumeric/issues/234
        elem.val(val);
    },

    getAutoNumericRawFloatValue: function (elem) {
        var replaceWith = {
            ',': '.',
            ' €': '',
            '_': ''
        };

        var val = elem.val();

        for (var replace in replaceWith) {
            if (replaceWith.hasOwnProperty(replace))
                val = val.replaceAll(replace, replaceWith[replace]);
        }

        if (val === '' || val === '.')
            return 0;

        return parseFloat(val);
    },

    fieldValidationError: function (fieldElem, message, isError) {
        isError = isError === undefined ? true : isError;

        var fieldValidation = fieldElem.parent().find('span[class*="field-validation"]'),
            isOk = !(message != null && message.length > 0);

        if (!isOk) {
            fieldValidation
                .removeClass('field-validation-valid')
                .addClass('field-validation-error')
                .text(message);

            if (isError)
                fieldElem[0].setCustomValidity('Erreur');
        } else {
            fieldValidation
                .addClass('field-validation-valid')
                .removeClass('field-validation-error')
                .text('');

            if (isError)
                fieldElem[0].setCustomValidity('');
        }

        fieldElem.closest('.form-group').toggleClass('has-error', !isOk);
    },

    /**
     * Adds a bootstrap input-group-addon
     * without losing events attached to fieldElem
     * @param {} fieldElem 
     * @param {} text 
     * @returns {} 
     */
    appendInputGroupAddon: function (fieldElem, text) {
        var parent = fieldElem.parent();

        return $('<div />')
            .addClass('input-group')
            .append(fieldElem.detach())
            .append(
                $('<span />')
                    .addClass('input-group-addon')
                    .text(text)
            )
            .appendTo(parent);
    }
};
