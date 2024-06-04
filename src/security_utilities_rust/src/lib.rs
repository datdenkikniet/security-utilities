// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

pub mod microsoft_security_utilities_core;

mod marvin_tests;
mod identifiable_secrets_tests;
mod cross_company_correlating_id_tests;

pub type IdentifiableScan = microsoft_security_utilities_core::identifiable_scans::Scan;
pub type IdentifiableScanOptions = microsoft_security_utilities_core::identifiable_scans::ScanOptions;
