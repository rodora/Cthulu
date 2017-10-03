# Cthulu
A guide for installing RoDora app with full unit unlocked. (**Android ONLY**)

(**Full unit requires ROOT**)

Notice
---
* If you already played RoDora, skip 1,2,5 in Instructions.
* If you already played RoDora and want full unit, skip instructions with `KeychainServices.xml`.

Instructions
----
1.Prepare following files:
* `KeychainServices.xml` (use your own file if exists)
* `CARewardPluginActivity.xml` (use your own file if exists)
* RoDora apk (also can download from Play Store)
* Decrypted AssetBundle(`AssetBundle_Decode`)

2.(Optional)Edit `CARewardPluginActivity.xml`, replace `RoDora` to your username
```html
    <string name="USERNAME">RoDora</string>
```
  
3.Encrypt `AssetBundle` from `AssetBundle_Decode` with `KeychainServices.xml` using `RTDDE.AssetBundleDecoder`

4.Put following files to specific folders (**CASE SENSITIVE**):
* `KeychainServices.xml` => `/sdcard/.acq-roadtodragons/`
* **Encrypted** `AssetBundle` => `/sdcard/Android/data/jp.co.acquire.RTD/files/`
* `CARewardPluginActivity.xml` => `/data/data/jp.co.acquire.RTD/shared_prefs/` (Optional, only for full unit)(**Requires ROOT**)

5.Install & Open RoDora. Eaten by Cthulu.