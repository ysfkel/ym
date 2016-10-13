

/**
 * @name ProductCollecion
 * @description Model for products
 */
function BlogCollection(service) {

    this.service = service
    this.data = [];
}

ProductCollection.prototype.fetch = function (url) {
    var collection = this;
    
    /**
     * uri of backend api that makes a call to the feed end point
     * 
     */
    var uri = '/api/apiblog';
    return this.service({
        url: uri,
        method: 'GET'
    }).then((res) => {
      //  this.data=res.data.product;
        return res;
    })
}


module.exports = BlogCollection;

