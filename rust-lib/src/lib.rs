#![allow(clippy::not_unsafe_ptr_arg_deref)]

use std::{ffi::CString, os::raw::c_char};

#[no_mangle]
pub extern "C" fn get_string() -> *mut c_char {
    let cs = CString::new("From Rust").unwrap();
    cs.into_raw()
}

#[no_mangle]
pub extern "C" fn free_string(ptr: *mut c_char) {
    if ptr.is_null() {
        return;
    }

    unsafe {
        CString::from_raw(ptr);
    }
}

#[repr(C)]
#[derive(Default)]
pub struct TestStruct {
    int_val: i64,
}

impl TestStruct {
    pub fn new() -> Self {
        Self { int_val: 1234 }
    }
}

#[no_mangle]
pub extern "C" fn get_struct() -> TestStruct {
    TestStruct::new()
}

#[cfg(test)]
mod tests {
    #[test]
    fn it_works() {
        assert_eq!(2 + 2, 4);
    }
}
