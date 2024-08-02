using DV.ThingTypes;
using HarmonyLib;
using UnityEngine;
using static baoli_DE2gg.Main;

namespace baoli_DE2gg
{
	[HarmonyPatch(typeof(TrainCar), "Start")]
class CarPatch {
	static void Postfix(ref TrainCar __instance)
	{
		if (__instance == null || __instance.carType != TrainCarType.LocoShunter)
		{
			return;
		}

		string De22bogPath = "LocoDE2_Body";
		Transform De22Bog = __instance.transform.Find(De22bogPath);
		if (De22Bog == null)
		{
			Error($"Couldn't find DE2r bog on '{__instance.transform.gameObject.name}' -> {De22bogPath}");
			return;
		}

		// Smoke Deflector
			Log($"Applying {MySettings.DE2GZlaliAType.ToString()}");

		switch (MySettings.DE2GZlaliAType) {
			case Settings.DE2GZlaliType.Chinese:
				ApplyChineseDE2gg(ref __instance, De22Bog);
				break;
		}

	}
		private static void ApplyChineseDE2gg(ref TrainCar locomotive, Transform body)
	{
		//hide 操作空間
		var ChineseDE2Path = "LocoDE2_Body/ext 621_exterior";
		Transform ChineseDE2bog = locomotive.transform.Find(ChineseDE2Path);
		ChineseDE2bog.gameObject.SetActive(false);

		var lodChineseDE2Path = "LocoDE2_Body/LocoShunterExterior_lod/ext 621_exterior_LOD1";
		Transform lodChineseDE2bog = locomotive.transform.Find(lodChineseDE2Path);
		lodChineseDE2bog.gameObject.SetActive(false);

		var lod2ChineseDE2Path = "LocoDE2_Body/LocoShunterExterior_lod/ext 621_exterior_LOD2";
		Transform lod2ChineseDE2bog = locomotive.transform.Find(lod2ChineseDE2Path);
		lod2ChineseDE2bog.gameObject.SetActive(false);

		var lod3ChineseDE2Path = "LocoDE2_Body/LocoShunterExterior_lod/ext 621_exterior_LOD3";
		Transform lod3ChineseDE2bog = locomotive.transform.Find(lod3ChineseDE2Path);
		lod3ChineseDE2bog.gameObject.SetActive(false);

			var ChineseDE2XPath = "LocoDE2_Body/Clapper";
		Transform ChineseDE2Xbog = locomotive.transform.Find(ChineseDE2XPath);
		ChineseDE2Xbog.gameObject.SetActive(false);
 
		var RlightglassPath = "[headlights_de2]/FrontSide/ext headlights_glass_red_F";
		Transform Rlightglass = locomotive.transform.Find(RlightglassPath);
		Rlightglass.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var ChineseDE2RedSPath = "[headlights_de2]/FrontSide/HeadlightTop/Glare";
		Transform RlightglassA = locomotive.transform.Find(ChineseDE2RedSPath);
		RlightglassA.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var ChineseDE2RedSFPath = "[headlights_de2]/FrontSide/ext headlights_glass_F";
		Transform ChineseDE2RedDSF = locomotive.transform.Find(ChineseDE2RedSFPath);
		ChineseDE2RedDSF.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var FFRlightglassPath = "[headlights_de2]/RearSide/ext headlights_glass_red_R";
		Transform FFRlightglass = locomotive.transform.Find(FFRlightglassPath);
		FFRlightglass.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var FFChineseDE2RedSPath = "[headlights_de2]/RearSide/HeadlightTop/Glare";
		Transform FFRlightglassA = locomotive.transform.Find(FFChineseDE2RedSPath);
		FFRlightglassA.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var FFChineseDE2RedSFPath = "[headlights_de2]/RearSide/ext headlights_glass_R";
		Transform FFChineseDE2RedDSF = locomotive.transform.Find(FFChineseDE2RedSFPath);
		FFChineseDE2RedDSF.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var righthailightPath = "[particles]/ExhaustEngineSmoke";
		Transform righthailight = locomotive.transform.Find(righthailightPath);
		righthailight.transform.localPosition = new Vector3(0.00f, -1998.00f, 0.00f);

		var righthailightAPath = "[particles]/HighTempEngineSmoke";
		Transform rAighthailight = locomotive.transform.Find(righthailightAPath);
		rAighthailight.transform.localPosition = new Vector3(0.00f, -1998.00f, 0.00f);

		var righthailightBPath = "[particles]/DamagedEngineSmoke";
		Transform rBighthailight = locomotive.transform.Find(righthailightBPath);
		rBighthailight.transform.localPosition = new Vector3(0.00f, -1998.00f, 0.00f);

		var FlightPath = "[headlights_de2]/FrontSide/HeadlightLeftLow/Glare";
		Transform Flight = locomotive.transform.Find(FlightPath);
		Flight.transform.localPosition = new Vector3(0.90f, 1.40f, 3.40f);

		var rrlightPath = "[headlights_de2]/FrontSide/HeadlightRightLow/Glare";
		Transform rrlight = locomotive.transform.Find(rrlightPath);
		rrlight.transform.localPosition = new Vector3(-0.90f, 1.40f, 3.40f);

		var hailightFPath = "[headlights_de2]/FrontSide/HeadlightLeftHigh/Glare";
		Transform hailight = locomotive.transform.Find(hailightFPath);
		hailight.transform.localPosition = new Vector3(0.90f, 1.40f, 3.40f);

		var hailightRPath = "[headlights_de2]/FrontSide/HeadlightRightHigh/Glare";
		Transform rrAlight = locomotive.transform.Find(hailightRPath);
		rrAlight.transform.localPosition = new Vector3(-0.90f, 1.40f, 3.40f);

		var RlightLLPath = "[headlights_de2]/RearSide/HeadlightLeftLow/Glare";
		Transform RlightLLa = locomotive.transform.Find(RlightLLPath);
		RlightLLa.transform.localPosition = new Vector3(0.90f, 1.40f, -3.40f);

		var RlightLRPath = "[headlights_de2]/RearSide/HeadlightRightLow/Glare";
		Transform RlightLRa = locomotive.transform.Find(RlightLRPath);
		RlightLRa.transform.localPosition = new Vector3(-0.90f, 1.40f, -3.40f);

		var RlightHLPath = "[headlights_de2]/RearSide/HeadlightLeftHigh/Glare";
		Transform RlightHLa = locomotive.transform.Find(RlightHLPath);
		RlightHLa.transform.localPosition = new Vector3(0.90f, 1.40f, -3.40f);

		var RlightHRPath = "[headlights_de2]/RearSide/HeadlightRightHigh/Glare";
		Transform RlightHRa = locomotive.transform.Find(RlightHRPath);
		RlightHRa.transform.localPosition = new Vector3(-0.90f, 1.40f, -3.40f);

		var RlightHRBeamPath = "[headlights_de2]/RearSide/HeadlightRightHigh/VolumetricBeam";
		Transform RlightHRaBeam = locomotive.transform.Find(RlightHRBeamPath);
		RlightHRaBeam.transform.localPosition = new Vector3(-0.90f, 1.40f, -3.40f);

		var RlightLeftHighPath = "[headlights_de2]/RearSide/HeadlightLeftHigh/VolumetricBeam";
		Transform RlightHRaLeftHigh = locomotive.transform.Find(RlightLeftHighPath);
		RlightHRaLeftHigh.transform.localPosition = new Vector3(0.90f, 1.40f, -3.40f);

		var RHeadlightRightLowPath = "[headlights_de2]/RearSide/HeadlightRightLow/VolumetricBeam";
		Transform RRearSideBeam = locomotive.transform.Find(RHeadlightRightLowPath);
		RRearSideBeam.transform.localPosition = new Vector3(-0.90f, 1.40f, -3.40f);

		var RHeadlightLeftLowPath = "[headlights_de2]/RearSide/HeadlightLeftLow/VolumetricBeam";
		Transform RRearSideHigh = locomotive.transform.Find(RHeadlightLeftLowPath);
		RRearSideHigh.transform.localPosition = new Vector3(0.90f, 1.40f, -3.40f);

		var FlightHRBeamPath = "[headlights_de2]/FrontSide/HeadlightRightHigh/VolumetricBeam";
		Transform FlightHRaBeam = locomotive.transform.Find(FlightHRBeamPath);
		FlightHRaBeam.transform.localPosition = new Vector3(-0.90f, 1.40f, 3.40f);

		var FlightLeftHighPath = "[headlights_de2]/FrontSide/HeadlightLeftHigh/VolumetricBeam";
		Transform FlightHRaLeftHigh = locomotive.transform.Find(FlightLeftHighPath);
		FlightHRaLeftHigh.transform.localPosition = new Vector3(0.90f, 1.40f, 3.40f);

		var FHeadlightRightLowPath = "[headlights_de2]/FrontSide/HeadlightRightLow/VolumetricBeam";
		Transform FRearSideBeam = locomotive.transform.Find(FHeadlightRightLowPath);
		FRearSideBeam.transform.localPosition = new Vector3(-0.90f, 1.40f, 3.40f);

		var FHeadlightLeftLowPath = "[headlights_de2]/FrontSide/HeadlightLeftLow/VolumetricBeam";
		Transform FRearSideHigh = locomotive.transform.Find(FHeadlightLeftLowPath);
		FRearSideHigh.transform.localPosition = new Vector3(0.90f, 1.40f, 3.40f);

		//show deflector and stuff
		GameObject chineseDE22bog = Object.Instantiate(DE2_laliPrefab, body);
		chineseDE22bog.transform.localPosition = ChineseDE2bog.localPosition;
	     }

	}

}
