/**
 * 
 */

G.db = {
	link : false,
	executeSQL : function(sql, par, fx) {
		if (G.db.link) {
			G.db.link.transaction(function(tx) {
				tx.executeSql(sql, par, fx);
			});
		}
	},
	initDB : function() {
		G.db
				.executeSQL('CREATE TABLE IF NOT EXISTS role (id int autoincrement not null, name varchar(30) not null, primary key(id)) ');
		G.db
				.executeSQL('CREATE TABLE IF NOT EXISTS user (id int autoincrement not null, user varchar(30) not null,name varchar(100) not null, password text not null,status varchar(15) not null,role int not null, primary key(id)) ');
	},
	openDB : function() {
		G.db.link = openDatabase("taskManager", "1.0",
				"Base de Datos Auxiliar Panchita TPV", 50 * 1024 * 1024);
		G.db.initDB();
	},
	insert : function(table, par, o, fx) {
		if (typeof par === "object") {
			var sql = "insert into " + table + "(";
			var k = [];
			var x = [];
			var v = [];
			for ( var i in par) {
				k.push(i);
				x.push("?");
				v.push(par[i]);
			}
			sql += k.join(",") + ") values(" + x.join(",") + ")";
			G.db.executeSQL(sql, v, function(tx, rs) {
				if (fx && fx.call) {
					fx(tx, rs, o);
				}
			});
		}
	},
	exists : function(table, par, o, fx, fy) {
		if (typeof par === "object") {
			var sql = "select 1 from " + table + " where ";
			var x = [];
			var v = [];
			for ( var i in par) {
				x.push(i + "=?");
				v.push(par[i]);
			}
			sql += x.join(" and ");
			G.db.executeSQL(sql, v, function(tx, rs) {
				if (rs && rs.rows) {
					if (rs.rows.length > 0) {
						(fx && fx.call) ? fx(o) : "";
					} else {
						(fy && fy.call) ? fy(o) : "";
					}
				}

			});
		}
	}
};

G.DB = {
	startDB : function() {
		var db = openDatabase('taskManager', '1.0', 'Task Manager',
				2 * 1024 * 1024);

		db
				.transaction(function(tx) {
					tx
							.executeSql('CREATE TABLE IF NOT EXISTS role (id int autoincrement not null, name varchar(30) not null, primary key(id)) ');
					tx
							.executeSql('CREATE TABLE IF NOT EXISTS user (id int autoincrement not null, user varchar(30) not null,name varchar(100) not null, password text not null,status varchar(15) not null,role int not null, primary key(id)) ');
				});
	}
};