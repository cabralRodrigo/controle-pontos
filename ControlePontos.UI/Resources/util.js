var util;
(function (util) {
    util.secondsToTimeSpan = function (seconds, plusSignal) {
        var addSignal = seconds < 0;

        var date = new Date(null);
        date.setSeconds(seconds < 0 ? seconds * -1 : seconds);

        if (plusSignal)
            return (seconds < 0 ? "-" : "+") + date.toISOString().toString().substr(11, 5);
        else
            return (addSignal < 0 ? "-" : "") + date.toISOString().toString().substr(11, 5);
    }

    return util;
})(util || (util = {}));