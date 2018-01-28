using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGenerator : MonoBehaviour {
	private string[] prefixes = new string[] {
	  "Attractive",
	  "Beautiful ",
	  "Better ",
	  "Careful ",
	  "Chubby ",
	  "Clean ",
	  "Clever ",
	  "Cute ",
	  "Dazzling ",
		"Shiny ",
		"Slick ",
		"Wet ",
	  "Determined ",
	  "Elegant ",
	  "Famous ",
	  "Fancy ",
	  "Flabby ",
	  "Gifted ",
	  "Glamorous ",
	  "Gorgeous ",
	  "Handsome ",
	  "Helpful ",
	  "Important ",
	  "Inexpensive ",
	  "Chompy ",
	  "Long ",
	  "Magnificent ",
	  "Marsh ",
	  "Mealy ",
	  "Muscular ",
	  "Mushy ",
	  "Nautical ",
		"Squishy ",
	  "Plain",
	  "Plump",
		"Juicy ",
	  "Odd",
	  "Powerful ",
	  "Speedy ",
	  "Scruffy ",
	  "Shapely ",
	  "Short ",
	  "Shy ",
	  "Skinny ",
	  "Spicy ",
	  "Squishy ",
	  "Stocky ",
	  "Sweet ",
	  "Tender ",
	  "Little ",
		"Lil ",
	  "Terrible ",
	  "Top Quality ",
	  "Unimportant ",
	  "Uninterested ",
	  "Unsightly ",
		"Tiny ",
		"Smol "
	};
	private string[]  mids = new string[] {
		"Abe",
		"Ale",
		"Aqua",
		"Archi",
		"Asp",
		"Battle",
		"Blerg",
		"Blinky",
		"Bloop",
		"Capri",
		"Carcha",
		"Cet",
		"Champ",
		"Chary",
		"Ches",
		"Clover",
		"Con",
		"Crocos",
		"Cthu",
		"Dianog",
		"Dino",
		"Dobh",
		"Dog",
		"Eleph",
		"Eri",
		"Gat",
		"Gigan",
		"Glob",
		"Gob",
		"Grill",
		"Grindy",
		"Guna",
		"Gung",
		"Hippo",
		"Hoo",
		"Hydra",
		"Iku",
		"Invert",
		"Iv",
		"Jag",
		"Jaws",
		"Jell",
		"Kapp",
		"Kelp",
		"Ken",
		"Kione",
		"Koi",
		"Kra",
		"La",
		"Leo",
		"Leviat",
		"Lob",
		"Lobst",
		"Lock",
		"Lusck",
		"Maka",
		"Marm",
		"Marsh",
		"Marsle",
		"Mega",
		"Melus",
		"Mer",
		"Merm",
		"Merp",
		"Mor",
		"Morg",
		"Na",
		"Ogo",
		"Orca",
		"Piranha",
		"Plati",
		"Pose",
		"Pro",
		"Qalu",
		"Rainbow",
		"Re",
		"Rhedo",
		"Rowo",
		"Rusk",
		"Saturn",
		"Scy",
		"Sea",
		"Selk",
		"Shark",
		"Shel",
		"Sig",
		"Sir",
		"Sizz",
		"Snaggle",
		"Snor",
		"Squ",
		"Swaggle",
		"Tia",
		"Tlan",
		"Tol",
		"Tri",
		"Turt",
		"Ulla",
		"Un",
		"Urs",
		"Verti",
		"Wha",
		"Xeno",
		"Yacu",
		"Zin"
	};

	private string[] ends = new string[]{
		"-mama",
		"-shiggle",
		"-squiggle",
		"-waggle",
		"-wiggle",
		"aconda",
		"adon",
		"ady",
		"agi",
		"alade",
		"alik",
		"alisk",
		"alka",
		"amat",
		"an",
		"anc",
		"anto",
		"aquiles",
		"ara",
		"araz",
		"ark",
		"arones",
		"ary",
		"athan",
		"ator",
		"azipan",
		"azoid",
		"berg",
		"brie",
		"ca",
		"chata",
		"chelone",
		"chu",
		"cotl",
		"dra",
		"edo",
		"etus",
		"eus",
		"gans",
		"gawr",
		"har",
		"iad",
		"iano",
		"ians",
		"ibrate",
		"icorn",
		"ies",
		"igandr",
		"ili",
		"ilk",
		"illia",
		"inion",
		"intinian",
		"ione",
		"ipsis",
		"is",
		"ish",
		"iteuthis",
		"ith",
		"itle",
		"jira",
		"ka",
		"ken",
		"le",
		"ling",
		"lith",
		"lla",
		"lows",
		"ly",
		"maid",
		"mo",
		"morph",
		"mund",
		"oad",
		"ocamp",
		"ocka",
		"odon",
		"oip",
		"onathus",
		"ophant",
		"ople",
		"opogo",
		"orax",
		"ork",
		"osaurus",
		"ow",
		"pa",
		"pie",
		"pire",
		"ren",
		"sapien",
		"saurus",
		"sea",
		"seidon",
		"seugo",
		"sie",
		"sil",
		"ster",
		"strosity",
		"thinx",
		"throp",
		"thulhu",
		"ton",
		"topus",
		"tucky",
		"tus",
		"uar",
		"udo",
		"uid",
		"ula",
		"uno",
		"urso",
		"urup",
		"usi",
		"usine",
		"ver",
		"woo",
		"y",
		"zilla",
		"zin"
	};

	public Text text;

  public string MakeName() {
		var nameprefix = "";
    if (Random.Range (0, 5) > 4){
      var prepick  = Random.Range (0, prefixes.Length);
      nameprefix = prefixes[prepick];
    }

    var midpick  = Random.Range (0, mids.Length);
    var namemid = mids[midpick];

    var endpick  = Random.Range (0, ends.Length);
    var nameend = ends[endpick];

    return string.Concat( string.Concat(nameprefix, namemid), nameend );
  }

	public void FillTextName(){
		text.text = MakeName ();
	}

  void Start() {

    for (var i = 0; i < 25; i++) {
      var name = MakeName();
      Debug.Log(name);
    }
  }

  void Update() {

  }


}
