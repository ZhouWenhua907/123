var _Config = {
    Server: "http://localhost:4014/api.ashx",
    Time_out: 10 * 100,
    PageSize: 20,
    Uid: "",
    Reload: 5 * 1000
};

(function () {
    if (!window["_P_M_"]) window["_P_M_"] = {};

    window._IF = {};

    window._IF.getJson = function (scope, url, param, sCallback, fCallBack, accessType, showMask, fsm, fem, onErrNoop) {
        var oldurl = url;
        var path = null;
        path = url;
        url = _Config.Server + url;

        console.log(url);

        accessType = accessType ? accessType : "GET";

        param = param ? param : {};

        var rtn;
        var t = scope ? scope : window;

        param["sigVer"] = "1";

        $.ajax({
            data: param,
            url: url,      //访问接口地址
            cache: false,
            dataType: "jsonp",
            jsonp: "callback",
            success: function (r) {
                if (t && (t._status_ === -1 || t._status_ === 1)) return;
                sCallback && sCallback.call(t, r);
            },
            error: function () {
                alert("程序出错，请联系管理员.");
            }
        });

    };

    //抽奖
    window._IF.LOTTERY = function (scope, param, cb, error) {
        !param && (param = {});
        var url = "?act=lottery";
        this.getJson(scope, url, param, cb, error, "GET");
    };



    //查询抽奖次数
    window._IF.LOTTERYNUM = function (scope, param, cb, error) {
        !param && (param = {});
        var url = "?act=lotterytNum";
        this.getJson(scope, url, param, cb, error, "GET");
    };




    //查询用户奖品
    window._IF.LOTTERYCOUPON = function (scope, param, cb, error) {
        !param && (param = {});
        var url = "?act=lotteryCoupon";
        this.getJson(scope, url, param, cb, error, "GET");
    };


}).call(window);
