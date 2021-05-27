/**
 * Caisse des Congés Payés - Extranet V4
 * Visite guidée
 * 
 * Steps are defined in _VisiteGuidee.cshtml
 */

(function() {
    var joyride,
        joyrideOptions,
        wizard,
        isRiding = false;

    var beginTour = function(wizard, joyrideOptions, forceStart) {
        // Destroy previous instance
        wizard.joyride('destroy');

        joyrideOptions.cookieMonster = !forceStart;

        joyride = wizard.joyride(joyrideOptions);
    };
    var appendHelpIconToHeader = function () {
        // Already added, abort
        if ($('.joyride-starter').length !== 0)
            return;

        // Add "help" action button to header
        $('<a />')
            .attr('href', '#')
            .attr('data-toggle', 'tooltip')
            .attr('data-placement', 'left')
            .attr('title', 'Aide')
            .addClass('action joyride-starter')
            .append(
                $('<i />')
                    .addClass('mdi mdi-help-circle')
            )
            .click(function () {
                beginTour(wizard, joyrideOptions, true);
            })
            .prependTo($('.header-right').find('.actions').first());
    };

    $(document).ready(function() {
        var visiteGuidee = $('body').data('visite-guidee');

        // There's no wizard for this page, skip
        if (visiteGuidee === undefined)
            return;

        // Find the right wizard from _VisiteGuidee.cshtml
        wizard = $('ol[data-visite-guidee="' + visiteGuidee + '"]');

        if (wizard.length !== 1) {
            console.error('Could not find the right wizard, aborting');
            return;
        }

        // Bind close event to not proceed
        $('body').on('click', '.joyride-close-tip', function () {
            isRiding = false;
        });

        // These are shared parameters from each joyride wizard
        var baseJoyrideOptions = {
            autoStart: true,
            cookieName: 'VisiteGuidee',
            modal: true,
            preRideCallback: function() {
                isRiding = true;
            },
            postRideCallback: function() {
                isRiding = false;
                appendHelpIconToHeader();
            }
        };
        var specificJoyrideOptions = {};

        // Here, we define parameters for each joyride wizard
        switch (visiteGuidee) {
            case 'profil':
                specificJoyrideOptions = {
                    pauseAfter: [3],
                    postStepCallback: function (index, tip) {
                        // Don't execute callback if ride is stopped
                        if (!isRiding)
                            return;

                        // Trigger some events depending on index
                        switch (index) {
                            case 3:
                                // Open and close some menu sections
                                var menuItems = $('nav > ul > li > a.menu-item[href="#"]').toArray();

                                var clickAndWait = function () {
                                    var menuItem = menuItems.shift();
                                    menuItem.click();

                                    if (menuItems.length > 0)
                                        setTimeout(clickAndWait, 500); // <- adjust delay here
                                    else
                                        joyride.joyride('resume');
                                };

                                clickAndWait();
                        }
                    }
                };
                break;
        }

        joyrideOptions = $.extend({}, baseJoyrideOptions, specificJoyrideOptions);

        // Init joyride once window will have finished loading
        $(window).load(function () {
            beginTour(wizard, joyrideOptions, false);

            if (!isRiding) // Tour hasn't started (cookie)
                appendHelpIconToHeader();
        });
    });
})();
