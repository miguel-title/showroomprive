/**
 * Password strength component
 * 
 * Usage:

<hr/>
<div class="col-sm-8 col-sm-offset-4">
    <div id="password-alert" class="alert"></div>
</div>
@Html.EditorFor(m => m.Password)
@Html.EditorFor(m => m.PasswordBis)

<script>
    $(document).ready(function() {
        $('#Password').passwordStrength({
            bisElem: $('#PasswordBis'),
            alert: $('#password-alert')
        });
    });
</script>

 */
(function ($, window) {
    var StrengthLevel = {
        WEAK: 'weak',
        MEDIUM: 'medium',
        STRONG: 'strong'
    };

    var PasswordStrength = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    PasswordStrength.prototype = {
        defaults: {
            bisElem: null,
            alert: null,
            submitButton: null,
            inputGroupAddons: null,

            rules: {
                minStrength: StrengthLevel.MEDIUM,
                minLength: 8,
                atLeastOneDigit: true,
                atLeastOneLetter: true,
                atLeastOneUppercaseLetter: false,
                atLeastOneSpecialChar: false
            }
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            if (this.settings.submitButton == null)
                this.settings.submitButton = this.elem.closest('form').find('[type="submit"]');

            this.elem.add(this.settings.bisElem)
                .on('keyup change', function() {
                    self.testStrengthLive();
                })
                .trigger('keyup');
        },

        testStrengthLive: function () {
            var self = this;
            var strengthArray = this.getStrength(this.elem.val(), this.settings.bisElem.val()),
                strength = strengthArray[0],
                strengthMessage = strengthArray[1],
                strengthColor = this.getStrengthColor(strength);

            this.elem.add(this.settings.bisElem).css('border-color', strengthColor);
            this.settings.alert[0].classList = 'alert alert-' + this.getAlertClass(strength);
            this.settings.alert
                .toggle(strengthMessage != null)
                .text(strengthMessage);
            
            if (strength === StrengthLevel.WEAK)
                this.settings.submitButton.attr('disabled', 'disabled');
            else
                this.settings.submitButton.removeAttr('disabled');

            this.elem.add(this.settings.bisElem).each(function() {
                $(this)
                    .parent()
                    .find('.input-group-addon')
                    .html(self.getInputGroupAddonContent(strength))
                    [0].classList = 'input-group-addon bg-' + self.getAlertClass(strength);
            });
        },

        getStrengthColor: function(strength) {
            return {
                'weak': '#D50000',
                'medium': '#0277BD',
                'strong': '#2E7D32'
            }[strength];
        },

        getAlertClass: function(strength) {
            return {
                'weak': 'danger',
                'medium': 'info',
                'strong': 'success'
            }[strength];
        },

        getInputGroupAddonContent: function(strength) {
            return {
                'weak': '<i class="mdi mdi-emoticon-sad"></i>',
                'medium': '<i class="mdi mdi-emoticon-happy"></i>',
                'strong': '<i class="mdi mdi-emoticon"></i>'
            }[strength];
        },

        getStrength: function (password, password2) {
            if (password.length === 0)
                return [StrengthLevel.WEAK, null];

            if (password.length < this.settings.rules.minLength)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins ' + this.settings.rules.minLength + ' caractères'];

            // Check if it contains numbers
            if (this.settings.rules.atLeastOneDigit) {
                if (!/\d/.test(password))
                    return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins un chiffre'];
            }

            // Check if it contains letters
            if (this.settings.rules.atLeastOneLetter) {
                if (!/[a-zA-Z]/.test(password))
                    return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins une lettre.'];
            }

            if (password !== password2 && password.length > 0)
                return [StrengthLevel.WEAK, 'Vous avez saisi deux mots de passe différents'];

            var level = StrengthLevel.MEDIUM;

            // Check if it contains uppercase letters
            var mustHaveUppercaseLetter = this.settings.rules.atLeastOneUppercaseLetter;
            var hasUppercaseLetter = /[A-Z]/.test(password);
            if (mustHaveUppercaseLetter && !hasUppercaseLetter)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins une majuscule.'];
            else if (!mustHaveUppercaseLetter && hasUppercaseLetter)
                level = StrengthLevel.MEDIUM;

            
            // Check if it contains special chars
            var mustHaveSpecialChar = this.settings.rules.atLeastOneSpecialChar;
            var hasSpecialChar = /[$-/:-?{-~!"^_`\[\]]/.test(password);
            if (mustHaveSpecialChar && !hasSpecialChar)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins un caractère spécial.'];
            else if (!mustHaveSpecialChar && hasSpecialChar)
                level = StrengthLevel.STRONG;
            
            // Check if its length is long enough to be strong
            if (password.length > 12)
                return [StrengthLevel.STRONG, null];

            return [level, null];
        }
    };

    PasswordStrength.defaults = PasswordStrength.prototype.defaults;

    $.fn.passwordStrength = function(options) {
        return new PasswordStrength(this, options).init();
    }

    window.PasswordStrength = PasswordStrength;
}(jQuery, window));
