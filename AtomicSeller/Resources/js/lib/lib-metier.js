/**
 * Caisse des Congés Payés - Extranet V4
 * Lib metier
 */

window.Metier = {
    getNumSSRawValue: function (elem) {
        return elem.val()
            .replaceAll('.', '')
            .replaceAll('/', '')
            .replaceAll('_', '');
    },

    getCleNumSS: function (numSS) {
        numSS = numSS.toLowerCase();
        var bMatricule = false;

        for (var i = 0, l = numSS.length; i < l; i++) {
            var letter = numSS[i];
            if (letter <= 'z' && letter >= 'c')
                bMatricule = true;
        }

        if (bMatricule)
            return '99';

        var _numSS = numSS.substr(0, 13),
            _presenceA = _numSS.indexOf('a') > -1,
            _presenceB = _numSS.indexOf('b') > -1;

        _numSS = _numSS
            .replaceAll('a', '0')
            .replaceAll('b', '0');

        var n = parseInt(_numSS);

        if (isNaN(n))
            return null;

        if (_presenceA)
            n -= 1000000;
        if (_presenceB)
            n -= 2000000;

        var cleSS = (97 - (n % 97)).toString();
        return cleSS.length == 1
            ? '0' + cleSS
            : cleSS;
    },

    getDateNaissance: function (numSS, numCaisse) {
        var result = {
            dateNaissance: null,
            dateNaissanceInconnue: null
        };

        var now = new Date();
        now.setFullYear(now.getUTCFullYear() - 16);

        var year = now.getFullYear(),
            iYear = parseInt(numSS.substr(1, 2));
        if (!isNaN(iYear))
            year = iYear;

        if (year < 30)
            year += 2000;
        else
            year += 1900;

        var month = now.getMonth() + 1,
            iMonth = parseInt(numSS.substr(3, 2));
        if (!isNaN(iMonth))
            month = iMonth;

        if (numCaisse == 34 || month > 0 && month <= 12 || numSS.substr(0, 13) == '0000000000000')
            result.dateNaissance = new Date(year, month - 1, 1);
        else
            result.dateNaissanceInconnue = year;

        return result;
    },

    getCodifTitre: function(titre) {
        switch (titre) {
            case 1:
                return ['010'];
            case 2:
                return ['020', '030'];
            default :
                return null;
        }
    },

    getTitreFromNumSS: function(numSS) {
        if (numSS.length == 0)
            return null;

        var s = parseInt(numSS.substr(0, 1));
        return s === 1 || s === 2 ? s : null;
    }
};
