export default function clearInfo(input) {
  if(input.nextElementSibling != null){
    input.nextElementSibling.remove();
  }
}