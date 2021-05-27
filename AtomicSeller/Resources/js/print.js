/**
 * Caisse des Congés Payés - Extranet V4
 * Fichier Javascript pour Impression
 */

// Replace all occurences
function domReady() {
    window.print();
}

// Mozilla, Opera, Webkit
if (document.addEventListener) {
    document.addEventListener("DOMContentLoaded",
        function () {
            document.removeEventListener("DOMContentLoaded", arguments.callee, false);
            domReady();
        },
        false);

    // If IE event model is used
} else if (document.attachEvent) {
    // ensure firing before onload
    document.attachEvent("onreadystatechange",
        function () {
            if (document.readyState === "complete") {
                document.detachEvent("onreadystatechange", arguments.callee);
                domReady();
            }
        });
}
