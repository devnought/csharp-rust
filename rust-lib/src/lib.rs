#![allow(clippy::not_unsafe_ptr_arg_deref)]

use std::{ffi::CString, os::raw::c_char};

#[no_mangle]
pub extern "C" fn get_string() -> *mut c_char {
    let s = String::from("From Rust");
    let cs = CString::new(s).unwrap();
    cs.into_raw()
}

#[no_mangle]
pub extern "C" fn get_string_free(ptr: *mut c_char) {
    if ptr.is_null() {
        return;
    }

    unsafe {
        CString::from_raw(ptr);
    }
}

#[cfg(test)]
mod tests {
    #[test]
    fn it_works() {
        assert_eq!(2 + 2, 4);
    }
}
