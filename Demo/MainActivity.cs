using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Pub.Devrel.Easypermissions;
using System.Linq;
using System.Collections.Generic;

namespace Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, EasyPermissions.IPermissionCallbacks
    {
        private readonly int RC_RECORD_VOICE = 0x0001;
        private readonly int RC_CAMERA = 0x0002;
        private readonly int RC_PHOTO = 0x0003;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestPermission();
        }
        


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            var results = grantResults.Select(item => (int)item).ToArray();
            EasyPermissions.OnRequestPermissionsResult(requestCode, permissions, results, this);

        }

        public void OnPermissionsDenied(int p0, IList<string> p1)
        {
            // Some permissions have been denied
        }

        public void OnPermissionsGranted(int p0, IList<string> p1)
        {
            // Some permissions have been granted
        }


        private void RequestPermission()
        {
            string[] perms ={
                     Android.Manifest.Permission.WriteExternalStorage,
                    Android.Manifest.Permission.Camera,
                    Android.Manifest.Permission.RecordAudio
            };

            // EasyPermissions.RequestPermissions(this, Resources.GetString(Resource.String.camera_and_location_rationale), RC_CAMERA, perms);

            var request = new PermissionRequest.Builder(this, RC_CAMERA, perms)
                .SetRationale("app need some Permissions")
                .SetPositiveButtonText("OK")
                .SetNegativeButtonText("reject")
                .SetTheme(Resource.Style.AlertDialog_AppCompat_Light)
                .Build();

            EasyPermissions.RequestPermissions(request);

        }

    }
}