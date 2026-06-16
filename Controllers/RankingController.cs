using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStudy.Data;
using WebStudy.Models;

namespace WebStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        //의존성 주입
        ApplicationDbContext _context;
        public RankingController(ApplicationDbContext InContext)
        {
            _context = InContext;
        }

        // GET api/Ranking
        //전체 조회
        [HttpGet]
        public List<GameResult> GetGameResult()
        {
            //스코어 기준 내림차순으로 전부 조회
            List< GameResult > results = _context.GameResults
                .OrderByDescending(item => item.Score)
                .ToList();
            return results;
        }
        //유연성과 메모리 효율을 위해 IEnumerable<GameResult>을 사용하는 코드
        //public IEnumerable<GameResult> GetGameResult()
        //{
        //    //스코어 기준 내림차순으로 전부 조회
        //    IEnumerable<GameResult> results = _context.GameResults
        //           .OrderByDescending(item => item.Score)
        //           .AsEnumerable();
        //    return results;
        //}

        //단일 조회
        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            //스코어 기준 내림차순으로 전부 조회
            GameResult? result = _context.GameResults
                .Where(item=>item.Id ==id).FirstOrDefault();
            return result;
        }

        // POST api/Ranking
        // DB에 자료 추가
        [HttpPost]
        public bool AddGameResult([FromBody] GameResult gameResult)
        {
            _context.GameResults.Add(gameResult); //DB에 자료 추가

            if (_context.SaveChanges() > 0) //DB 변경사항 확정하기
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT api/Ranking/1
        // DB에 있는 자료 수정
        [HttpPut("{id}")]
        public bool UpdateGameResult(int id,[FromBody] int NewScore)
        {
            GameResult? result = _context.GameResults
                .Where(item => item.Id == id).FirstOrDefault();
            if (result ==null)
            {
                return false;
            }
            result.Score = NewScore;
            result.FixDate = DateTime.Now;
            if (_context.SaveChanges() > 0) //DB 변경사항 확정하기
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE api/Ranking/1
        //단일 자료 삭제
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            GameResult? result = _context.GameResults
                .Where(item => item.Id == id)
                .FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            _context.GameResults.Remove(result);
             if (_context.SaveChanges() > 0) //DB 변경사항 확정하기
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
