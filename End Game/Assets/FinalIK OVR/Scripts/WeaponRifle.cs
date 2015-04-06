using UnityEngine;
using System.Collections;

namespace RootMotion.FinalIK.Demos {

	public class WeaponRifle : WeaponBase {
		
		[Header("Shooting")]
		public Transform shootFrom;
		public float range = 300f;
		public LayerMask hitLayers;
		
		[Header("Particle FX")]
		public ParticleSystem muzzleFlash;
		public ParticleSystem muzzleSmoke;
		public ParticleSystem bulletHole;
		public ParticleSystem bulletHit;
		public float smokeFadeOutSpeed = 5f;
		
		private float smokeEmission;
	
		// Emit particles, bullets...
		public override void Fire() {
			muzzleFlash.Emit(1);
			smokeEmission = 10f;
			
			RaycastHit hit;
			if (!Physics.Raycast(shootFrom.position, shootFrom.forward, out hit, range, hitLayers)) return;
			
			bulletHole.transform.position = hit.point + hit.normal * 0.01f;
			bulletHole.Emit(1);
			
			bulletHit.transform.position = bulletHole.transform.position;
			bulletHit.Emit(20);
		}
		
		void Update() {
			// Fade out the smoke emitter
			smokeEmission = Mathf.Max(smokeEmission - Time.deltaTime * smokeFadeOutSpeed, 0f);
			
			muzzleSmoke.enableEmission = smokeEmission > 0f;
			muzzleSmoke.emissionRate = smokeEmission;
		}
	}
}
