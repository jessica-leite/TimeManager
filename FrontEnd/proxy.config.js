const proxy = [
    {
      context: '/api',
      target: 'http://localhost:50292/api',
      pathRewrite: {'^/api' : ''}
    }
  ];
  
  module.exports = proxy;