(this.webpackJsonpviewer=this.webpackJsonpviewer||[]).push([[0],{33:function(t,e,n){t.exports=n(40)},38:function(t,e,n){},39:function(t,e,n){},40:function(t,e,n){"use strict";n.r(e);var r=n(0),a=n.n(r),o=n(23),i=n.n(o),c=n(19),l=n(14),s=(n(38),window.allFrames||[{bots:[{id:1,name:"No Data"}],fleets:[],planets:[]}]),u=["grey","green","red","blue","purple","orange","#FED106"],f=function(t,e){var n=s[e].planets.find((function(e){return e.id===t.sourcePlanetID})),r=s[e].planets.find((function(e){return e.id===t.destinationPlanetID})),a=n.position,o=r.position,i={x:o.x-a.x,y:o.y-a.y},c=Math.atan2(i.x,-i.y)*(180/Math.PI),l=t.position,u=l.x,f=l.y;return{points:"".concat(u,",").concat(f-12," ").concat(u+9,",").concat(f+12," ").concat(u-9,",").concat(f+12),transform:"rotate(".concat(c," ").concat(u," ").concat(f,") translate(0 -6)")}},p=function(){var t=Object(r.useRef)(null),e=Object(r.useState)(0),n=Object(c.a)(e,2),o=n[0],i=n[1],p=Object(r.useState)(!0),d=Object(c.a)(p,2),m=d[0],y=d[1];Object(r.useEffect)((function(){if(m){var t=setInterval((function(){return i((function(t){return Math.min(t+1,s.length-1)}))}),150);return function(){return clearInterval(t)}}}),[m]);var v=Object(r.useCallback)((function(){o+1===s.length&&i(0),y(!0)}),[o]);Object(r.useEffect)((function(){var t=function(t){if(32===t.keyCode)t.preventDefault(),m?y(!1):v();else if(37===t.keyCode){t.preventDefault();var e=o-1;e=Math.max(e,0),i(e),y(!1)}else if(39===t.keyCode){t.preventDefault();var n=o+1;n=Math.min(s.length-1,n),i(n),y(!1)}};return document.addEventListener("keydown",t),function(){return document.removeEventListener("keydown",t)}}),[m,v,o]),Object(r.useEffect)((function(){if(t.current){var e=l.b(t.current),n=e.selectAll("g.fleet").data(s[o].fleets.slice().reverse(),(function(t){return t.id})),r=n.enter().append("g").classed("fleet",!0);r.append("polygon").attr("class","fleet").attr("points",(function(t){return f(t,o).points})).attr("transform",(function(t){return f(t,o).transform})).attr("fill",(function(t){return u[t.ownerID]})).attr("stroke","#000").attr("stroke-width","1").attr("opacity",.75),r.append("text").style("font-size",14).attr("text-anchor","middle").attr("dy",".4em").attr("fill","#fff").attr("x",(function(t){return t.position.x})).attr("y",(function(t){return t.position.y})).attr("opacity",.75).text((function(t){return t.numberOfShips})),n.select("polygon").transition().ease(l.a).duration(150).attr("points",(function(t){return f(t,o).points})).attr("transform",(function(t){return f(t,o).transform})).attr("opacity",1),n.select("text").transition().ease(l.a).duration(150).attr("x",(function(t){return t.position.x})).attr("y",(function(t){return t.position.y})).text((function(t){return t.numberOfShips})).attr("opacity",1),n.exit().remove();var a=e.selectAll("g.planet").data(s[o].planets),i=a.enter().append("g").classed("planet",!0);i.append("circle").attr("cx",(function(t){return t.position.x})).attr("cy",(function(t){return t.position.y})).attr("r",(function(t){return 8+3*t.growthRate})).attr("fill",(function(t){return u[t.ownerID]})).attr("stroke","#000").attr("stroke-width","1"),i.append("text").style("font-size",14).attr("text-anchor","middle").attr("dy",".4em").attr("fill","#fff").attr("x",(function(t){return t.position.x})).attr("y",(function(t){return t.position.y})).text((function(t){return t.numberOfShips})),a.select("circle").attr("fill",(function(t){return u[t.ownerID]})),a.select("text").text((function(t){return t.numberOfShips})),a.exit().remove()}}),[t,o]);return a.a.createElement("div",{className:"app"},a.a.createElement("div",{style:{padding:"4px 8px",position:"absolute",zIndex:10}},s[0].bots.map((function(t,e){return[0===e?null:a.a.createElement("span",null,"\xa0vs\xa0"),a.a.createElement("span",{style:{color:u[t.id]}},t.name)]}))),a.a.createElement("div",{className:"game-container"},a.a.createElement("div",{className:"game",style:{position:"relative"}},a.a.createElement("svg",{ref:t,viewBox:"0 0 500 510",style:{width:"100%",height:"100%"}}))),a.a.createElement("div",{className:"topbar",style:{display:"flex",flexDirection:"row",width:"100%",position:"absolute",bottom:0}},a.a.createElement("div",{className:"progress-bar",style:{backgroundColor:"#333",height:"30px",flex:1},onClick:function(t){var e=t.currentTarget.getBoundingClientRect(),n=e.left,r=e.width,a=100*(t.clientX-n)/r,o=Math.round(s.length*a/100);o=Math.min(o,s.length-1),i(o)}},a.a.createElement("div",{style:{backgroundColor:"slategrey",height:"100%",width:"".concat(100*o/(s.length-1),"%")}},"\xa0")),a.a.createElement("div",{style:{width:"80px",color:"#ccc",textAlign:"center",backgroundColor:"black"}},o+1," / ",s.length),a.a.createElement("div",{className:"button ".concat(m?"active":null),onClick:function(){return v()}},"Play"),a.a.createElement("div",{className:"button ".concat(m?null:"active"),onClick:function(){return y(!1)}},"Stop")))};n(39);i.a.render(a.a.createElement(p,null),document.getElementById("root"))}},[[33,1,2]]]);
//# sourceMappingURL=main.fdb6dc3e.chunk.js.map