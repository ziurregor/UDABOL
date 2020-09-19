<html>
<head>
</head>
<body>
<script language="JavaScript">
var n = System.Int32.parse(prompt());
            var  a= System.Array.init(((n + 1) | 0), 0, System.Int32);
            var l = System.Array.init(((n + 1) | 0), 0, System.Int32);
            var t = System.Array.init(((n + 1) | 0), 0, System.Int32);

            for (var i = 1; i < n; i = (i + 1) | 0) {
                var x = System.Int32.parse(prompt());
                var y = System.Int32.parse(prompt());
                a[System.Array.index(y, a)] = x;
                l[System.Array.index(y, l)] = System.Int32.parse(prompt());
                t[System.Array.index(y, t)] = System.Int32.parse(prompt());

            }
            var r = 0;
            for (var j = 1; j < ((n + 1) | 0); j = (j + 1) | 0) {
                var e = System.Double.parse(prompt());
                if (e >= 0) {
                    var re = j;
                    while (re > 1) {
                        if (t[System.Array.index(re, t)] === 1) {
                            e = Math.sqrt(e);
                        }

                        e = e * ((((100, l[System.Array.index(re, l)])) | 0));
                        re = a[System.Array.index(re, a)];

                    }
                    if (e > r) {
                        r = e;
                    }
                }
            }
            System.Console.WriteLine(System.Double.format(r));
        }
</script>
</body>
</html>