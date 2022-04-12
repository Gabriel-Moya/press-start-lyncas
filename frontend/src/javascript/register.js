import validateFields from "./modules/validations/validateFields.js";
import registerUser from "./modules/registerUser.js";
import updateUser from "./modules/updateUser.js";

const idUrl = location.href.split("?id=")[1];

validateFields();

if (idUrl != undefined) {
  updateUser();
} else {
  registerUser();
}