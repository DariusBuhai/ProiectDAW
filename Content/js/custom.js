
function toggleHideByClass(className, hide = true){
    let el = document.getElementsByClassName(className);
    for(let i=0;i<el.length;i++)
        el[i].hidden= hide;
}

function toggleRemoveByClass(className, classToRemove){
    let el = document.getElementsByClassName(className);
    for(let i=0;i<el.length;i++)
        el[i].classList.remove(classToRemove);
}

function changeActiveSection(id){
    toggleRemoveByClass("section-item","active");
    document.getElementsByClassName("section-item-"+id)[0].classList.add("active");
    toggleHideByClass("project-section-item", true);
    document.getElementsByClassName("project-section-item-"+id)[0].hidden = false;
}

function copyToClipboard(copyText){
    let tempInput = document.createElement("input");
    tempInput.value = copyText;
    document.body.appendChild(tempInput);
    tempInput.select();
    document.execCommand("copy");
    document.body.removeChild(tempInput);
}

<!-- Global site tag (gtag.js) - Google Analytics -->
window.dataLayer = window.dataLayer || [];
function gtag(){dataLayer.push(arguments);}
gtag('js', new Date());

gtag('config', 'UA-163958714-1');