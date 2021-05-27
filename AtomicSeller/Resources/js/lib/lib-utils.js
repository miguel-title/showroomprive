/**
 * Caisse des Congés Payés - Extranet V4
 * Lib utils
 */

window.Utils = {
    /**
     * Updates/adds a parameter in the query string
     * http://stackoverflow.com/questions/5999118/add-or-update-query-string-parameter
     */
    updateQueryString: function(key, value, url) {
        if (!url) url = window.location.href;
        var re = new RegExp("([?&])" + key + "=.*?(&|#|$)(.*)", "gi"),
            hash;

        if (re.test(url)) {
            if (typeof value !== 'undefined' && value !== null)
                return url.replace(re, '$1' + key + "=" + value + '$2$3');
            else {
                hash = url.split('#');
                url = hash[0].replace(re, '$1$3').replace(/(&|\?)$/, '');
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                return url;
            }
        } else {
            if (typeof value !== 'undefined' && value !== null) {
                var separator = url.indexOf('?') !== -1 ? '&' : '?';
                hash = url.split('#');
                url = hash[0] + separator + key + '=' + value;
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                return url;
            } else
                return url;
        }
    },

    commaSeparatedValues: function(array) {
        if (array.length === 0)
            return '';

        var t = '';
        for (var i = 0, l = array.length; i < l; i++)
            t += array[i] + ',';

        // Remove trailing comma
        return t.substr(0, t.length - 1);
    },

    extract: function(array, func) {
        var a = [];

        for (var i = 0, l = array.length; i < l; i++)
            a.push(func(array[i]));

        return a;
    },

    parseDate: function(ddmmyyyy) {
        if (ddmmyyyy.length != 'dd/mm/yyyy'.length)
            return null;

        var day = ddmmyyyy.substr(0, 'dd'.length),
            month = ddmmyyyy.substr('dd/'.length, 'mm'.length),
            year = ddmmyyyy.substr('dd/mm/'.length, 'yyyy'.length);

        return new Date(year, month - 1, day);
    },

    addEventHandler: function(array, type, func) {
        for (var i = 0, l = array.length; i < l; i++)
            $(array[i].bind(type, func));
    },

    setIsLoading: function (state) {
        $('body').toggleClass('loading', state);
    }
};
