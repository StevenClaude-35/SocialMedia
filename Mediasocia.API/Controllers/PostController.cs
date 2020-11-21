using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Repositories;
using socialMediaCore.Dtos;
using socialMediaCore.Entities;
using socialMediaCore.Interfaces;

namespace Mediasocia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = _mapper.Map <IEnumerable<PostDto>>(posts);
            //var postsDto = posts.Select(x => new PostDto
            //{
            //    PostId = x.PostId,
            //    Date = x.Date,
            //    Description = x.Description,
            //    Image = x.Image,
            //    UserId = x.UserId
            //});
            return Ok(postsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            //var postDto = new PostDto
            //{
            //    PostId = post.PostId,
            //    Date = post.Date,
            //    Description = post.Description,
            //    Image = post.Image,
            //    UserId = post.UserId
            //};
            return Ok(postDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = _mapper.Map<Post>(postdto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,PostDto postdto)
        {
           
            var post = _mapper.Map<Post>(postdto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var post = _mapper.Map<Post>(postdto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}
