(this.webpackJsonpappclient=this.webpackJsonpappclient||[]).push([[0],{20:function(e,t,n){e.exports=n.p+"static/media/loading.fb0e16bc.svg"},25:function(e,t,n){e.exports=n(40)},30:function(e,t,n){},32:function(e,t,n){},40:function(e,t,n){"use strict";n.r(t);var a=n(0),r=n.n(a),c=n(12),l=n.n(c),i=(n(30),n(7)),o=n.n(i),s=n(13),m=n(5),u=(n(32),n(10)),p=n(22),d=n(23),b=n(14),f=n.n(b),h=function(e){return e.items?r.a.createElement(r.a.Fragment,null,r.a.createElement("h2",{className:"text-center border-bottom mb-4"},"Search for: ",e.term),r.a.createElement("ul",null,e.items.map((function(e){return r.a.createElement("div",{className:"row m-2",key:e._id},r.a.createElement("div",{className:"col-md-4"},r.a.createElement("img",{src:e.thumbnail,className:"img img-thumbnail",alt:e.title})),r.a.createElement("div",{className:"col-md-8"},r.a.createElement("h4",null,"Title: ",e.title),r.a.createElement("p",null,"Description: ",e.description),r.a.createElement("p",null,"Published: ",f()(e.publishedAt).format("DD/MM/YYYY"))))})))):r.a.createElement("div",null)},E=n(15);function g(){var e=Object(E.a)(["\n    margin: 30px 0 500px 0;\n    padding: 0 15px;\n    display: flex;\n    align-items: center;\n    justify-content: center;\n    font-weight: 700;\n    color: #7f4ba2;\n\n    img {max-width: 60px;}\n"]);return g=function(){return e},e}var v=n(16).a.div(g()),w=n(20),j=n.n(w),O=function(e){return r.a.createElement(v,null,e.icon&&r.a.createElement("img",{src:j.a,alt:"Carregando..."}),e.label)},x=function(e){var t=Object(a.useState)(!1),n=Object(m.a)(t,2),c=n[0],l=n[1],i=Object(a.useState)([]),b=Object(m.a)(i,2),f=b[0],E=b[1],g=Object(a.useState)(!1),v=Object(m.a)(g,2),w=v[0],j=v[1],x=Object(a.useState)(""),y=Object(m.a)(x,2),S=y[0],N=y[1],Y=Object(a.useState)(""),k=Object(m.a)(Y,2),D=k[0],A=k[1];function B(){return(B=Object(s.a)(o.a.mark((function e(t){return o.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,fetch("/Youtube/"+t);case 2:e.sent.json().then((function(e){return E(e)}),l(!1)).catch((function(e){return j(e)}));case 4:case"end":return e.stop()}}),e)})))).apply(this,arguments)}return r.a.createElement("div",{className:"container mt-5"},r.a.createElement("div",{className:"row"},r.a.createElement("form",{className:"w-100",onSubmit:function(e){e.preventDefault(),l(!0),function(e){B.apply(this,arguments)}(S),A(S)}},r.a.createElement(u.a,{className:"mb-3"},r.a.createElement(p.a,{placeholder:"Search on Youtube","aria-label":"Search on Youtube","aria-describedby":"basic-addon2",value:S,onChange:function(e){return N(e.target.value)}}),r.a.createElement(u.a.Append,null,r.a.createElement(d.a,{type:"submit",variant:"outline-secondary"},"Go!"))))),w&&r.a.createElement("p",null,"See console for errors :("),c&&r.a.createElement(O,{label:"Loading, please wait ;)",icon:!0}),!c&&r.a.createElement(h,{items:f.items,term:D}))};Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));n(39);l.a.render(r.a.createElement(x,null),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then((function(e){e.unregister()})).catch((function(e){console.error(e.message)}))}},[[25,1,2]]]);
//# sourceMappingURL=main.6a8e7484.chunk.js.map