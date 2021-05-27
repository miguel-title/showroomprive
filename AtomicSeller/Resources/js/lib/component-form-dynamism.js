/**
 * Form Dynamism
 * Usage:
 * 
 * $('#elem-to-be-hidden').visibilityCondition({params})
 * 
 * Modes:
 *  - Condition (function)
 *  {
 *      condition: function(elem, trigger) {
 *          // Some complicated code
 *          return true; // <- return true or false
 *      }
 *  }
 * 
 *  - Condition (value)
 *  {
 *      condition: '010' // elem will be shown if trigger.val() == '010'
 *  }
 * 
 *  - Condition (array)
 *  {
 *      condition: ['010', '020', '030'] // elem will be shown if its value matches one of this item elements
 *  }
 * 
 */
(function ($, window) {
    /**
     * @param {} elem Element to be shown/hidden
     * @param {} options 
     * @returns {} 
     */
    var VisibilityCondition = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    VisibilityCondition.prototype = {
        defaults: {
            condition: null,
            /**
             * When this element's value changes, condition is called
             */
            trigger: null,
            /**
             * When this event is fired on the trigger, condition is called
             */
            event: 'change',
            /**
             * Will use toggle if false
             */
            animate: true
        },

        init: function() {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            // Bind event
            var event = this.settings.event;
            this.settings.trigger.on(event, function () {
                self.updateVisibility();
            });

            // Update visibility
            this.updateVisibility();
        },

        updateVisibility: function () {
            var result = false;
            var triggerVal = this.settings.trigger.val();

            if (typeof this.settings.condition === "string") { // Singlevalue
                result = triggerVal === this.settings.condition;
            } else if (typeof this.settings.condition === "object") { // Array
                result = this.settings.condition.indexOf(triggerVal) !== -1;
            } else if (typeof this.settings.condition === "function") { // Function
                result = this.settings.condition(this.elem, this.settings.trigger);
            }

            if (result !== true && result !== false)
                return;

            if (this.settings.animate)
                this.elem.fadeInOrOut(result);
            else
                this.elem.toggle(result);
        }
    };

    VisibilityCondition.defaults = VisibilityCondition.prototype.defaults;

    $.fn.visibilityCondition = function(options) {
        return new VisibilityCondition(this, options).init();
    }

    window.VisibilityCondition = VisibilityCondition;
}(jQuery, window));
