import axios from "axios";
import { toast } from "react-toastify";

// Custom error handler, or do it with axio interceptors for bigger projects
export const handleError = (error: any) => {
  if (axios.isAxiosError(error)) {
    var err = error.response;
    if (Array.isArray(err?.data.errors)) {
      for (let val of err?.data.errors) {
        toast.warning(val.description);
      }
    } else if (typeof err?.data.errors === "object") {
      for (let e in err?.data.errors) {
        toast.warning(err.data.errors[e][0]);
      }
    } else if (err?.data) {
      if (Array.isArray(err?.data)) {
        for (let val of err?.data) {
          toast.warning(val.description);
        }
      } else toast.warning(err.data);
    } else if (err?.status == 401) {
      toast.warning("please login");
      window.history.pushState({}, "LoginPage", "/login");
    } else if (err) {
      toast.warning(err?.data);
    } else {
      console.log("Unkown error");
    }
  }
};
