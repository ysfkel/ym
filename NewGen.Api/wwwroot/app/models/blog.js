
/**
 * @name Blog model
 * @description Model for products
 */
  function Blog(service){
    this.service=service;
    this.data={};
    this.data.id,
    this.data.title;
    this.data.dateposted;
    this.data.text;
}

Blog.prototype.fetch=function(){

}


module.exports=Blog;