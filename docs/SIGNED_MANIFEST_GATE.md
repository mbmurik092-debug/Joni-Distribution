# Joni Signed Manifest Gate

`Joni Bootstrap Launcher v0.1.8` verifies a remote manifest cryptographically before parsing or trusting its contents.

## Development test trust root

- key id: `joni-dev-root-rsa3072-v1`
- algorithm: RSA-3072
- signature: RSASSA-PKCS1-v1_5
- hash: SHA-256
- trust tier: `development-test`

The private key is **not** stored in this repository. Only the public verification parameters are published for transparency.

## Signed manifest

- `manifests/signed-stable.json`
- detached signature: `manifests/signed-stable.json.sig`
- sequence: `1`
- expiry: `2026-11-26T23:59:59Z`

## Verification order

1. Fetch manifest bytes over approved HTTPS.
2. Fetch detached Base64 signature over approved HTTPS.
3. Verify RSA/SHA-256 signature using the public key embedded in Launcher.
4. Only after signature PASS, parse JSON.
5. Validate identity, key id, channel, time window, minimum launcher version and hardware profile.
6. Enforce anti-rollback `sequence` state.
7. Download each approved component, verify SHA-256, stage, install and health-check.
8. Commit the new highest accepted sequence only after the complete transaction passes.

## Anti-rollback

A manifest with a lower sequence than the highest locally accepted sequence is blocked. A different manifest at the same sequence is also blocked. Re-running the exact same signed manifest is allowed.

## Production note

This RSA key is a development gate key only. Before distributing real executables or LLM manifests, create a new production root key offline, define key-rotation/revocation policy and keep the production private key outside GitHub and normal runtime storage.
