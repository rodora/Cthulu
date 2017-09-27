# Cthulu
A guide for installing RoDora app with full unit unlocked. (**Android ONLY**)

(**Full unit requires ROOT**)

Howto
----
1.Prepare following files:
* `KeychainServices.xml` (use your own file if exists)
* `CARewardPluginActivity.xml`
* RoDora apk
* Decrypted AssetBundle(`AssetBundle_Decode`)

2.(Optional)Edit `CARewardPluginActivity.xml`, replace `RoDora` to your username
```html
    <string name="USERNAME">RoDora</string>
```
  
3.Encrypt `AssetBundle` from `AssetBundle_Decode` with `KeychainServices.xml` using `RTDDE.AssetBundleDecoder`

4.Put following files to specific folders (CASE SENSITIVE):
* `KeychainServices.xml` => `/sdcard/.acq-roadtodragons/`
* `CARewardPluginActivity.xml` => `/data/data/jp.co.acquire.RTD/shared_prefs/` (**Requires ROOT**)
* **Encrypted** `AssetBundle` => `/sdcard/Android/data/jp.co.acquire.RTD/files/`

5.Install & Open RoDora. Eaten by Cthulu.
